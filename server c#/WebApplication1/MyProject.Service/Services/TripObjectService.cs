using AutoMapper;
using MyProject.Common.Entities;
using MyProject.Repository.Entities;
using MyProject.Repository.Interfaces;
using MyProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Services
{

    public class TripObjectService : ITripObjectService
    {
        private readonly ITripObjectRepository tripObjectRepository;
        private readonly IPropertiesRepository propertiesRepository;
        private readonly IMapper mapper;
        public TripObjectService(ITripObjectRepository repository, IPropertiesRepository repository1, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.tripObjectRepository = repository;
            this.propertiesRepository = repository1;
        }
        public async Task<TripObjectDto> AddItem(TripObjectDto item)
        {
            TripObject trip = new TripObject
            {
                TripName = item.TripName,
                Description = item.Description,
                CategoryId = item.CategoryId,
                AreaId = item.AreaId,
                PropertiesList = new List<Properties>(),
                Lat = item.Lat,
                Lng = item.Lng,
                Location = item.Location
            };
            foreach (var item1 in item.PropertiesList)
            {
                Properties p = await propertiesRepository.GetById(item1);
                trip.PropertiesList.Add(p);
            }

            TripObject newTrip = await tripObjectRepository.AddItem(trip);
            TripObjectDto tripResponse = new TripObjectDto
            {
                TripId = (int)newTrip.TripId,
                TripName = newTrip.TripName,
                Description = newTrip.Description,
                CategoryId = newTrip.CategoryId,
                AreaId = newTrip.AreaId,
                PropertiesList = new List<int>(),
                Lat = newTrip.Lat,
                Lng = newTrip.Lng,
                Location = newTrip.Location
            };

            foreach (var item1 in newTrip.PropertiesList)
            {
                tripResponse.PropertiesList.Add(item1.PropertyId);
            }

            return tripResponse;

        }

        public async Task DeleteItem(int id)
        {
            await tripObjectRepository.DeleteItem(id);
        }

        public async Task<List<TripObjectDto>> GetAll()
        {
            return mapper.Map<List<TripObjectDto>>(await tripObjectRepository.GetAll());
        }

        public async Task<List<TripObjectDto>> GetByAreaId(int id)
        {
            List<TripObject> lst = await tripObjectRepository.GetByAreaId(id);
            List<TripObjectDto> lstDto = new List<TripObjectDto>();
            foreach (var item in lst)
            {
                TripObjectDto tripResponse = new TripObjectDto
                {
                    TripId = item.TripId,
                    TripName = item.TripName,
                    Description = item.Description,
                    CategoryId = item.CategoryId,
                    AreaId = item.AreaId,
                    PropertiesList = new List<int>(),
                    Lat = item.Lat,
                    Lng = item.Lng,
                    Location = item.Location
                };
                foreach (var item1 in item.PropertiesList)
                {
                    tripResponse.PropertiesList.Add(item1.PropertyId);
                }
                lstDto.Add(tripResponse);
            }


            return lstDto;
        }

        public async Task<TripObjectDto> GetById(int id)
        {

            return mapper.Map<TripObjectDto>(await tripObjectRepository.GetById(id));
        }

        public async Task UpdateItem(TripObjectDto item, int id)
        {
            await tripObjectRepository.UpdateItem(mapper.Map<TripObject>(item), id);
        }
    }
}
