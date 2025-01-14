using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repository;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Use case for adding a vehicle.
    /// </summary>
    public class ReturnVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IMapper mapper) : IUseCase<ReturnVehicleUseCaseInput, ReturnVehicleUseCaseOutput>
    {
        /// <summary>
        /// Executes the use case with the specified input.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        public async Task<ReturnVehicleUseCaseOutput> Execute(ReturnVehicleUseCaseInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            var vehicle = await vehicleRepository.FindById(input.Id);
            vehicle.ReturnVehicle();
            await vehicleRepository.ReturnVehicle(vehicle);
            return mapper.Map<ReturnVehicleUseCaseOutput>(vehicle);
        }
    }
}
