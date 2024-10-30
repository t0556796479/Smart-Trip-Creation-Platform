using Microsoft.EntityFrameworkCore;
using MyProject.Repository.Entities;
using MyProject.Repository.Interfaces;

namespace MyProject.Model
{
    public class MyDataContext:DbContext,IContext
    {
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Filters> Filters { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TripObject> TripObjects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocaldb;database=mydb;trusted_connection=true");
        }

        public async Task SaveChanges()
        {
            await SaveChangesAsync();
        }
    }
}