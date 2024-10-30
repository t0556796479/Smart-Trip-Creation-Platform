using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class CategoriesDto
    {
        public int ?CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
