using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProject.Repository.Entities
{
    public class TripObject
    {
        [Key]
        public int TripId { get; set; }
        public string TripName { get; set; }
        public string Description { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }

        [ForeignKey("Areas")]
        public int AreaId { get; set; }
        public Areas Areas { get; set; }
        public virtual ICollection<Properties> PropertiesList { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Location { get; set; }
    }
}
