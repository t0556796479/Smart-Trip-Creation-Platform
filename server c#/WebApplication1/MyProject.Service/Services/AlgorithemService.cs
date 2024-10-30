using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using MyProject.Common.Entities;
using MyProject.Repository.Entities;
using MyProject.Repository.Interfaces;
using MyProject.Repository.Repositories;
using MyProject.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace MyProject.Service.Services
{
    public class AlgorithemService : IAlgorithemService
    {

        private LocationPointDto startPoint;
        private LocationPointDto endPoint;
        private int areaId;
        private List<AgendaStepDto> agenda;
        private List<TripObjectDto> tripObjectsByArea;
        private List<TripObjectDto> algorithemResult;
        private Dictionary<int, List<TripObjectDto>> stepsDictionary;



        private readonly ITripObjectService tripObjectService;
        private readonly IFiltersService filtersService;
        private readonly IPropertiesService propertiesService;
        private readonly IMapper mapper;
        public AlgorithemService(ITripObjectService tripObjectService, IMapper _mapper, IFiltersService filtersService, IPropertiesService propertiesService)
        {
            this.filtersService = filtersService;
            this.tripObjectService = tripObjectService;
            this.mapper = _mapper;
            this.propertiesService = propertiesService;
            agenda = new List<AgendaStepDto>();
            tripObjectsByArea = new List<TripObjectDto>();
            algorithemResult = new List<TripObjectDto>();
            stepsDictionary = new Dictionary<int, List<TripObjectDto>>();

        }


        //Step1FilterTripsByArea :מסנן את כל רשימת האוביקטים לפי האזור שהתקבל
        private async Task Step1FilterTripsByArea()
        {
            tripObjectsByArea = await tripObjectService.GetByAreaId(areaId);
        }


        //Step2FilterAgendaByProperties: בעבור כל נקודה בסדר היום נוצרת רשימה של כל האוביקטים המתאימים לאוביקט זה לפי המאפינים הנדרשים
        private async Task Step2FilterAgendaByProperties()
        {
            foreach (var item in agenda)
            {
                //מסנן מתוך כל האוביקטים את האוביקטים המתאימים לפילטר זה  
                var lst = getTripsByFilrer(item);
                //מסנן מתוך כל האוביקטים את האוביקטים המתאימים למאפינים של נקודה זו  
                lst = getTripsByProperties(lst, item);
                stepsDictionary.Add(item.Id, lst);
            }
        }

        private List<TripObjectDto> getTripsByFilrer(AgendaStepDto a)
        {
            var result = from trip in tripObjectsByArea//בעבור כל אוביקט של האזור הנבחר
                         from p in trip.PropertiesList//תעבור על רשימת המאפינים שלו
                         where p == a.propertiesIdList.First()// ותבדוק האם בכלל האוביקט הנוכחי הוא באותו פילטר של האוביקט שהתקבל-(המאפין הראשון הוא הפילטר)ד) 
                         select trip;
            return result.ToList();
        }

        //הפעולה מחזירה את רשימת המקומות עם המאפינים הזהים למאפין שנשלח
        private List<TripObjectDto> getTripsByProperties(List<TripObjectDto> lst, AgendaStepDto aa)
        {
            aa.propertiesIdList.RemoveAt(0);//מוחק את הפילטר
            List<int> properties = aa.propertiesIdList;
            foreach (TripObjectDto item in lst)//בעבור כל אוביקט עם באזור שנבחר ועם הפילטר שנבחר
            {
                foreach (var p in properties)//תעבור על רשימת המאפינים
                {
                    if (!item.PropertiesList.Contains(p))//ותבדוק אם המאפינן אינו  קיים ברשימת המאפינים
                    {
                        lst.Remove(item);//תמחוק אותו מרשימת האוביקטים
                        break;
                    }
                }
            }
            return lst;

        }





        //עובר על כל המילון ובעבור כל נקודה בסדר היום עובר על כל האוביקטים האופצינלים ובוחר מתוכם את הקצר ביותר
        private async Task Srep3FilterAgendaByDistance()
        {
            LocationPointDto prevPoint = null;
            if (stepsDictionary.Count == 1)
            {
                TripObjectDto t = await ClosestPointAsync(endPoint, stepsDictionary.First().Value);
                algorithemResult.Add(t);
            }
            else
            {
                foreach (var (id, lst) in stepsDictionary)
                {
                    if (id == 1)
                    {
                        TripObjectDto t = await ClosestPointAsync(startPoint, lst);
                        algorithemResult.Add(t);
                        prevPoint = new LocationPointDto(t.Lat, t.Lng, t.Location);
                    }
                    else
                    {
                        if (lst.Count != 0)
                        {
                            if (id == stepsDictionary.Count)
                            {
                                TripObjectDto t = await ClosestPointAsync(endPoint, lst);
                                algorithemResult.Add(t);
                            }
                            else
                            {
                                TripObjectDto t = await ClosestPointAsync(prevPoint, lst);
                                algorithemResult.Add(t);
                                prevPoint = new LocationPointDto(t.Lat, t.Lng, t.Location);
                            }
                        }

                    }

                }
            }

        }

        private async Task<TripObjectDto> ClosestPointAsync(LocationPointDto p, List<TripObjectDto> lst)
        {
            double minDistance = double.MaxValue;
            TripObjectDto minDistanceTripObject = null;
            if (lst.Count == 1)
            {
                return lst[0];
            }
            else
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    TripObjectDto t = lst[i];
                    LocationPointDto tp = new LocationPointDto(t.Lat, t.Lng, t.Location);
                    double distance = await DistanceBetweenTwoPointsAsync(p, tp);
                    if (distance != -1 && distance < minDistance)
                    {
                        minDistance = distance;
                        minDistanceTripObject = t;
                    }

                }

            }
            return minDistanceTripObject;

        }

        public async Task<double> DistanceBetweenTwoPointsAsync(LocationPointDto p1, LocationPointDto p2)
        {
            string apikey = "AIzaSyAAhl5foyLrR4WkD41vLU74ptG18N4yfZE";
            string mode = "driving";
            string origin = $"{p1.Lat},{p1.Lng}";
            string destination = $"{p2.Lat},{p2.Lng}";
            string url = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={origin}&destinations={destination}&mode={mode}&key={apikey}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GoogleMapsApiResponse>(jsonString);

                    if (data.Status == "OK" && data.Rows.Length > 0 && data.Rows[0].Elements.Length > 0)
                    {
                        int distanceInMeters = data.Rows[0].Elements[0].Distance.Value;
                        double distanceInKilometers = distanceInMeters / 1000.0;
                        return distanceInKilometers;
                    }
                }
            }
            return -1;


        }



        //נקודה אחרונה והחזרת המסלול
        private async Task<List<TripObjectDto>> Step4()
        {
            return algorithemResult;
        }

        public async Task<List<TripObjectDto>> GetRoute(AlgorithemRequestDto algorithemRequest)
        {
            this.startPoint = algorithemRequest.StartPoint;
            this.endPoint = algorithemRequest.EndPoint;
            this.areaId = algorithemRequest.AreaId;
            this.agenda = algorithemRequest.Agenda;
            await Step1FilterTripsByArea();
            await Step2FilterAgendaByProperties();
            await Srep3FilterAgendaByDistance();
            return await Step4();
        }

        public async Task<List<PropertyFilterDto>> GetPropertiesByCategoryId(int categoryId)
        {
            List<PropertyFilterDto> propertyFilterDtos = new List<PropertyFilterDto>();
            List<FiltersDto> filters = await filtersService.GetByCategoryId(categoryId);
            foreach (FiltersDto filter in filters)
            {
                List<PropertiesDto> properties = await propertiesService.GetByFilterId(filter.FilterId);
                propertyFilterDtos.Add(new PropertyFilterDto(filter, properties));

            }
            return propertyFilterDtos;
        }
    }
}
