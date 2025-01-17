﻿using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindAvailable;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindById;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCase<AddVehicleUseCaseInput, AddVehicleUseCaseOutput>, AddVehicleUseCase>();
            services.AddScoped<IUseCaseList<FindAllAvailableVehiclesUseCaseInput, FindAllAvailableVehiclesUseCaseOutput>, FindAllAvailableVehiclesUseCase>();
            services.AddScoped<IUseCase<FindVehicleUseCaseInput, FindVehicleUseCaseOutput>, FindVehicleUseCase>();
            services.AddScoped<IUseCase<RentVehicleUseCaseInput, RentVehicleUseCaseOutput>, RentVehicleUseCase>();
            services.AddScoped<IUseCase<ReturnVehicleUseCaseInput, ReturnVehicleUseCaseOutput>, ReturnVehicleUseCase>();

            return services;
        }
    }
}
