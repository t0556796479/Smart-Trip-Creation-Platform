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
    public class UserRepository : ILogin<User>
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }
        public async Task<User> AddItem(User item)
        {

            await _context.Users.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            User u = _context.Users.FirstOrDefault(x => x.UserId == id);
            if (u != null)
            {
                _context.Users.Remove(u);
                await _context.SaveChanges();
            }
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public User? Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            return user;
        }

        public async Task UpdateItem(User item, int id)
        {
            User u = _context.Users.FirstOrDefault(x => x.UserId == id);
            if (u != null)
            {
                u.Name = item.Name;
                u.Email = item.Email;
                u.UserName = item.UserName;
                u.Password = item.Password;
                u.Role = item.Role;
                await _context.SaveChanges();
            }
        }
    }
}
