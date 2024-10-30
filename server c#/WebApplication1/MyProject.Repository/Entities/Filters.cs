using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Entities
{
    public class Filters
    {
        [Key]
        public int FilterId { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public string FilterName { get; set; }

    }
}
