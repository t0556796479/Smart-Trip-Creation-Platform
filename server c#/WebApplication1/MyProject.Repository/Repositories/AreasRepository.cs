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
    public class AreasRepository : IRepository<Areas>
    {

        private readonly IContext _context;
        public AreasRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Areas> AddItem(Areas item)
        {
            await _context.Areas.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }


        public async Task DeleteItem(int id)
        {
            Areas a = _context.Areas.FirstOrDefault(x => x.AreaId == id);
            if (a != null)
            {
                _context.Areas.Remove(a);
                await _context.SaveChanges();
            }
        }

        public async Task<Areas> GetById(int id)
        {
            return await _context.Areas.FirstOrDefaultAsync(x => x.AreaId == id);
        }

        public async Task<List<Areas>> GetAll()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task UpdateItem(Areas item, int id)
        {
            Areas a = _context.Areas.FirstOrDefault(x => x.AreaId == id);
            if (a != null)
            {
                a.AreaName = item.AreaName;
               await _context.SaveChanges();
            }
        }
    }
}
