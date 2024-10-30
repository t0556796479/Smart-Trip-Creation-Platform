using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class AlgorithemRequestDto
    {
        public LocationPointDto StartPoint { get; set; }
        public LocationPointDto EndPoint { get; set; }
        public List<AgendaStepDto> Agenda { get; set; }
        public int AreaId { get; set; }
    }
}
