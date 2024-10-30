using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Entities
{
    public class Properties
    {
        [Key]
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        

        [ForeignKey("Filters")]
        public int FilterId { get; set; }
        public Filters Filter { get; set; }
        public virtual ICollection<TripObject> ObjectsList { get; set; }
    }
}
