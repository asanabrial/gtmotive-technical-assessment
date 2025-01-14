using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindAvailable;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindById;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Api
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<Vehicle, AddVehicleUseCaseOutput>();
            CreateMap<Vehicle, RentVehicleUseCaseOutput>();
            CreateMap<Vehicle, ReturnVehicleUseCaseOutput>();
            CreateMap<Vehicle, FindVehicleUseCaseOutput>();
            CreateMap<Vehicle, FindAllAvailableVehiclesUseCaseOutput>();
        }
    }
}
