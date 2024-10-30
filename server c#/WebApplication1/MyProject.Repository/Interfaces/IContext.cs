using Microsoft.EntityFrameworkCore;
using MyProject.Repository.Entities;


namespace MyProject.Repository.Interfaces
{
    public interface IContext
    {

        public DbSet<Areas> Areas { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Filters> Filters { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TripObject> TripObjects { get; set; }
        public Task SaveChanges();
    }
}
