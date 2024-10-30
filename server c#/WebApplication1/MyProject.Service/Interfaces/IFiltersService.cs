using MyProject.Common.Entities;
using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Interfaces
{
    public interface IFiltersService:IService<FiltersDto>
    {
        public Task<List<FiltersDto>> GetByCategoryId(int categoryId);
    }
}
