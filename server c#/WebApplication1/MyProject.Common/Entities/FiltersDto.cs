using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class FiltersDto
    {
        public int FilterId { get; set; }
        public int CategoryId { get; set; }
        public string FilterName { get; set; }
    }
}
