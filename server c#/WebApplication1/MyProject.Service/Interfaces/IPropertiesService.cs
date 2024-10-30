using MyProject.Common.Entities;
using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Interfaces
{
    public interface IPropertiesService:IService<PropertiesDto>
    {
        public Task<List<PropertiesDto>> GetByFilterId(int filterId);

    }
}
