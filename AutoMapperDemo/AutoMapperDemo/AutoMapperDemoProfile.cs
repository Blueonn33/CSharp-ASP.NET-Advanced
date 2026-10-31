using AutoMapper;
using AutoMapperDemo.Models;
using AutoMapperDemo.Services.Data;
using AutoMapperDemo.ViewModels;

namespace AutoMapperDemo
{
    public class AutoMapperDemoProfile : Profile
    {
        public AutoMapperDemoProfile()
        {
            CreateMap<Vehicle, AllVehiclesDto>()
                .ForMember(d => d.Seats, opt => opt.MapFrom(s => s.Seats + 1));

            CreateMap<AllVehiclesDto, VehicleViewModel>()
                .ForMember(d => d.ProductionDate, opt => opt.MapFrom(s => s.ProductionDate.ToShortDateString()));
        }
    }
}
