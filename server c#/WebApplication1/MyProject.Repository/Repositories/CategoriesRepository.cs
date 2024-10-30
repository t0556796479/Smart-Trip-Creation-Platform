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
    public class CategoriesRepository : IRepository<Categories>
    {
        private readonly IContext _context;
        public CategoriesRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Categories> AddItem(Categories item)
        {
            await _context.Categories.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            Categories c = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (c != null)
            {
                _context.Categories.Remove(c);
                await _context.SaveChanges();
            }
        }

        public async Task<List<Categories>> GetAll()
        {
            return await _context.Categories.ToListAsync();

        }

        public async Task<Categories> GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public async Task UpdateItem(Categories item, int id)
        {
            Categories c = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (c != null)
            {
                c.CategoryName = item.CategoryName;
                await _context.SaveChanges();
            }
        }
    }
}
