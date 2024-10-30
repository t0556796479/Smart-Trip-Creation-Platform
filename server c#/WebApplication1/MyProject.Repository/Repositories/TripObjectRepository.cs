using Microsoft.EntityFrameworkCore;
using MyProject.Repository.Entities;
using MyProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Repositories
{
    public class TripObjectRepository : ITripObjectRepository
    {
        private readonly IContext _context;
        public TripObjectRepository(IContext context)
        {
            _context = context;
        }
        public async Task<TripObject> AddItem(TripObject item)
        {
            await _context.TripObjects.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            TripObject t = _context.TripObjects.FirstOrDefault(x => x.TripId == id);
            if (t != null)
            {
                _context.TripObjects.Remove(t);
                await _context.SaveChanges();
            }
        }

        public async Task<List<TripObject>> GetAll()
        {
            return await _context.TripObjects.ToListAsync();
        }

        public async Task<List<TripObject>> GetByAreaId(int id)
        {

            var tripObjects = await _context.TripObjects
                .Include(x => x.PropertiesList)
                .Where(x => x.AreaId == id)
               .ToListAsync();
            return tripObjects;

        }

        public async Task<TripObject> GetById(int id)
        {
            return await _context.TripObjects.FirstOrDefaultAsync(x => x.TripId == id);
        }


        public async Task UpdateItem(TripObject item, int id)
        {
            TripObject t = _context.TripObjects.FirstOrDefault(x => x.TripId == id);
            if (t != null)
            {
                t.TripName = item.TripName;
                t.Description = item.Description;
                t.CategoryId = item.CategoryId;
                t.AreaId = item.AreaId;
                await _context.SaveChanges();
            }
        }
    }
}
