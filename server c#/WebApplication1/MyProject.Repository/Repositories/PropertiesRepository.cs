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

    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly IContext _context;
        public PropertiesRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Properties> AddItem(Properties item)
        {
            await _context.Properties.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            Properties p = _context.Properties.FirstOrDefault(x => x.PropertyId == id);
            if (p != null)
            {
                _context.Properties.Remove(p);
                await _context.SaveChanges();
            }
        }

        public async Task<List<Properties>> GetAll()
        {
            return await _context.Properties.ToListAsync();

        }

        public async Task<List<Properties>> GetByFilterId(int filterId)
        {
            return await _context.Properties.Where(x => x.FilterId == filterId).ToListAsync();
        }

        public async Task<Properties> GetById(int id)
        {
            return await _context.Properties.FirstOrDefaultAsync(x => x.PropertyId == id);
        }


        public async Task UpdateItem(Properties item, int id)
        {
            Properties p = _context.Properties.FirstOrDefault(x => x.PropertyId == id);
            if (p != null)
            {
                p.PropertyName = item.PropertyName;
                p.FilterId = item.FilterId;
                await _context.SaveChanges();
            }


        }
    }
}
