using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Interfaces
{
    public interface IPropertiesRepository : IRepository<Properties>
    {
        //GetByFilterId - מחזיר את כל המאפינים ששיכים לפילטר שנשלח  
        public Task<List<Properties>> GetByFilterId(int filterId);
    }
}
