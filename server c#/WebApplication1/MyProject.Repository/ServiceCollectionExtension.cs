using Microsoft.Extensions.DependencyInjection;
using MyProject.Repository.Entities;
using MyProject.Repository.Interfaces;
using MyProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IRepository<Areas>, AreasRepository>();
            service.AddScoped<IRepository<Categories>, CategoriesRepository>();
            service.AddScoped<IFiltersRepository, FiltersRepository>();
            service.AddScoped<IPropertiesRepository, PropertiesRepository>();
            service.AddScoped<ITripObjectRepository, TripObjectRepository>();
            service.AddScoped<ILogin<User>, UserRepository>();
            return service;
        }
    }
}
