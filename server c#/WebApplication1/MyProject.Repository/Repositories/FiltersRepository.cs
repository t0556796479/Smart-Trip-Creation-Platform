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
    public class FiltersRepository : IFiltersRepository
    {
        private readonly IContext _context;
        public FiltersRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Filters> AddItem(Filters item)
        {
            await _context.Filters.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            Filters f = _context.Filters.FirstOrDefault(x => x.FilterId == id);
            if (f != null)
            {
                _context.Filters.Remove(f);
                await _context.SaveChanges();
            }
        }

        public async Task<List<Filters>> GetAll()
        {
            return await _context.Filters.ToListAsync();
        }

        public async Task<List<Filters>> GetByCategoryId(int categoryId)
        {
            return await _context.Filters.Where(x=> x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Filters> GetById(int id)
        {
            return await _context.Filters.FirstOrDefaultAsync(x => x.FilterId == id);
        }

        public async Task UpdateItem(Filters item, int id)
        {
            Filters f = _context.Filters.FirstOrDefault(x => x.FilterId == id);
            if (f != null)
            {
                f.CategoryId = item.CategoryId;
                f.FilterName = item.FilterName;
                await _context.SaveChanges();
            }

        }
    }
}
