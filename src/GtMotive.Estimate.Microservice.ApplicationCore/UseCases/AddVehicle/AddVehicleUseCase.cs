using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repository;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle
{
    /// <summary>
    /// Use case for adding a vehicle.
    /// </summary>
    public class AddVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IMapper mapper) : IUseCase<AddVehicleUseCaseInput, AddVehicleUseCaseOutput>
    {
        /// <summary>
        /// Executes the use case with the specified input.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        public async Task<AddVehicleUseCaseOutput> Execute(AddVehicleUseCaseInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var newVehicle = Vehicle.Create(
                make: input.Make,
                model: input.Model,
                year: input.Year,
                licensePlate: input.LicensePlate,
                fleetId: input.FleetId);

            await vehicleRepository.Add(newVehicle);

            return mapper.Map<AddVehicleUseCaseOutput>(newVehicle);
        }
    }
}
