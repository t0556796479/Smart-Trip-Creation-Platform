using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Entities
{
    public class Areas
    {
        [Key]
        public int AreaId { get; set; }
        public string AreaName { get; set; }

    }
}
