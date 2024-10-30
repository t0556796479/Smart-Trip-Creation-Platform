using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Interfaces
{
    public interface IFiltersRepository : IRepository<Filters>
    {
        //GetByCategoryId - מחזיר את כל הפילטרים בקטגוריה שנשלחה 
        public Task<List<Filters>> GetByCategoryId(int categoryId);
    }
}
