using Microsoft.Extensions.DependencyInjection;
using MyProject.Common.Entities;
using MyProject.Repository;
using MyProject.Service.Interfaces;
using MyProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service
{
    public static class ServiceCollectionExtension
    {
        //הגדרת התלויות
        public static IServiceCollection AddServices(this IServiceCollection service)
        {

            service.AddRepositories();
            service.AddScoped<IService<AreasDto>, AreasService>();
            service.AddScoped<IService<CategoriesDto>, CategoriesService>();
            service.AddScoped<IFiltersService, FiltersService>();
            service.AddScoped<IPropertiesService, PropertiesService>();
            service.AddScoped<ITripObjectService, TripObjectService>();
            service.AddScoped<ILoginService, UserService>();
            service.AddScoped<IAlgorithemService, AlgorithemService>();


            service.AddAutoMapper(typeof(MapperProfile));

            return service;
        }
    }
}
