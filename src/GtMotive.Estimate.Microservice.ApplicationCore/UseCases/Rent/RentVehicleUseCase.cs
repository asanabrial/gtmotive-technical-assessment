using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repository;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent
{
    /// <summary>
    /// Use case for adding a vehicle.
    /// </summary>
    public class RentVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IMapper mapper) : IUseCase<RentVehicleUseCaseInput, RentVehicleUseCaseOutput>
    {
        /// <summary>
        /// Executes the use case with the specified input.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        public async Task<RentVehicleUseCaseOutput> Execute(RentVehicleUseCaseInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            var vehicle = await vehicleRepository.FindById(input.Id)
                          ?? throw new InvalidOperationException(ErrorMessage.VehicleNotFound.ToString());

            vehicle.Rent(input.RentUserId);
            await vehicleRepository.Rent(vehicle);
            return mapper.Map<RentVehicleUseCaseOutput>(vehicle);
        }
    }
}
