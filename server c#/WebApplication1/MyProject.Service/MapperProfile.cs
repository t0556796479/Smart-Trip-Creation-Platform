using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Common.Entities;
using MyProject.Repository.Entities;
using MyProject.Service.Interfaces;
using MyProject.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service
{
    public class MapperProfile : Profile
    {
       // private readonly IPropertiesService _propertiesService;

     
        public MapperProfile()
        {
            CreateMap<Areas, AreasDto>().ReverseMap();
            CreateMap<Categories, CategoriesDto>().ReverseMap();
            CreateMap<Filters, FiltersDto>().ReverseMap();
            CreateMap<Properties, PropertiesDto>().ReverseMap();
            CreateMap<TripObject, TripObjectDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }


        //public MapperProfile(IServiceProvider serviceProvider)
        //{
        //    _propertiesService = serviceProvider.GetRequiredService<IPropertiesService>();

        //    CreateMap<Areas, AreasDto>().ReverseMap();
        //    CreateMap<Categories, CategoriesDto>().ReverseMap();
        //    CreateMap<Filters, FiltersDto>().ReverseMap();
        //    CreateMap<Properties, PropertiesDto>().ReverseMap();

        //    //        CreateMap<TripObject, TripObjectDto>()
        //    //            .ForMember(dest => dest.TripId, opt => opt.MapFrom(src => src.TripId))
        //    //            .ForMember(dest => dest.TripName, opt => opt.MapFrom(src => src.TripName))
        //    //            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        //    //            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
        //    //            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId))
        //    //            .ForMember(dest => dest.PropertiesList, opt => opt.MapFrom(src => src.PropertiesList.Select(p => p.PropertyId)))
        //    //            .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
        //    //            .ForMember(dest => dest.Lng, opt => opt.MapFrom(src => src.Lng))
        //    //            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

        //    //        CreateMap<TripObjectDto, TripObject>()
        //    //           .ForMember(dest => dest.TripId, opt => opt.MapFrom(src => src.TripId))
        //    //           .ForMember(dest => dest.TripName, opt => opt.MapFrom(src => src.TripName))
        //    //           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        //    //           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
        //    //           .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId))
        //    //           .ForMember(dest => dest.PropertiesList, opt => opt.MapFrom(src => src.PropertiesList.Select(id => _propertiesService.GetById(id))))
        //    //           .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
        //    //           .ForMember(dest => dest.Lng, opt => opt.MapFrom(src => src.Lng))
        //    //           .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

        //    //        CreateMap<TripObject, TripObjectDto>()
        //    //.ForMember(dest => dest.TripId, opt => opt.MapFrom(src => src.TripId))
        //    //.ForMember(dest => dest.TripName, opt => opt.MapFrom(src => src.TripName))
        //    //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        //    //.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
        //    //.ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId))
        //    //.ForMember(dest => dest.PropertiesList, opt => opt.MapFrom(src => src.PropertiesList.Select(p => p.PropertyId)))
        //    //.ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
        //    //.ForMember(dest => dest.Lng, opt => opt.MapFrom(src => src.Lng))
        //    //.ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

        //    //        CreateMap<TripObjectDto, TripObject>()
        //    //            .ForMember(dest => dest.TripId, opt => opt.MapFrom(src => src.TripId))
        //    //            .ForMember(dest => dest.TripName, opt => opt.MapFrom(src => src.TripName))
        //    //            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        //    //            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
        //    //            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId))
        //    //            .ForMember(dest => dest.PropertiesList, opt => opt.Ignore()) // אין צורך במיפוי זה, נשאיר עבור AutoMapper לטפל
        //    //            .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
        //    //            .ForMember(dest => dest.Lng, opt => opt.MapFrom(src => src.Lng))
        //    //            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

        //    CreateMap<TripObject, TripObjectDto>().ReverseMap();
        //    CreateMap<User, UserDto>().ReverseMap();
        //}
    }
}
