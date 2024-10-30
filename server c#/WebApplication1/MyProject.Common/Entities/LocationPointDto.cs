using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class LocationPointDto
    {
        public LocationPointDto(double lat, double lng, string location)
        {
            Lat = lat;
            Lng = lng;
            Location = location;
        }

        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Location { get; set; }


    }
}
