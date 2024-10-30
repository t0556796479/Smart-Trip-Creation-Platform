using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class PropertiesDto
    {
        public int ?PropertyId { get; set; }
        public string PropertyName { get; set; }
        public int FilterId { get; set; }
    }
}
