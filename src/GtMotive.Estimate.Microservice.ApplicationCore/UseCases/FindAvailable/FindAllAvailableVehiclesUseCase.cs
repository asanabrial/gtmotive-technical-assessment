using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repository;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindAvailable
{
    /// <summary>
    /// Use case for adding a vehicle.
    /// </summary>
    public class FindAllAvailableVehiclesUseCase(
        IVehicleRepository vehicleRepository,
        IMapper mapper) : IUseCaseList<FindAllAvailableVehiclesUseCaseInput, FindAllAvailableVehiclesUseCaseOutput>
    {
        /// <summary>
        /// Executes the use case with the specified input.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        public async Task<IEnumerable<FindAllAvailableVehiclesUseCaseOutput>> Execute(FindAllAvailableVehiclesUseCaseInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            return mapper.Map<IEnumerable<FindAllAvailableVehiclesUseCaseOutput>>(await vehicleRepository.FindAllAvailable(input.FleetId));
        }
    }
}
