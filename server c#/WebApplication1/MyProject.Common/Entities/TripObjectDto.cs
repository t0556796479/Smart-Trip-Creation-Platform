using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class TripObjectDto
    {
        public int TripId { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Location { get; set; }
        public string TripName { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int AreaId { get; set; }
        public List<int> PropertiesList { get; set; }

    }
}
