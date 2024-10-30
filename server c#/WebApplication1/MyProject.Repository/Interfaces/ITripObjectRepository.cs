using MyProject.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Interfaces
{
    public interface ITripObjectRepository : IRepository<TripObject>
    {
        //GetByAreaId - מחזיר את כל האוביקטים שבאזור שנשלח
        public Task<List<TripObject>> GetByAreaId(int id);

    }
}
