using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class PropertyFilterDto
    {
        public PropertyFilterDto(FiltersDto filter, List<PropertiesDto> properties)
        {
            this.filter = filter;
            this.properties = properties;
        }

        //זהו אוביקט  שמכיל לכל פילטר את רשימת המאפינים שלו
        public FiltersDto filter { get; set; }

        //רשימת המאפינים של הפילטר הנוכחי
        public List<PropertiesDto> properties { get; set; }
    }
}
