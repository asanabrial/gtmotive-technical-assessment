using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repository;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindById
{
    /// <summary>
    /// Use case for adding a vehicle.
    /// </summary>
    public class FindVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IMapper mapper) : IUseCase<FindVehicleUseCaseInput, FindVehicleUseCaseOutput>
    {
        /// <summary>
        /// Executes the use case with the specified input.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        public async Task<FindVehicleUseCaseOutput> Execute(FindVehicleUseCaseInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            return mapper.Map<FindVehicleUseCaseOutput>(await vehicleRepository.FindById(input.Id));
        }
    }
}
