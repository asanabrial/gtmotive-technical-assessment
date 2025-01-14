using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Repository interface.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a vehicle to the database.
        /// </summary>
        /// <param name="bson"> The vehicle to add. </param>
        /// <returns>Task of adding a vehicle. </returns>
        Task Add(Vehicle bson);

        /// <summary>
        /// Get a vehicle by its identifier.
        /// </summary>
        /// <param name="id"> The identifier of the vehicle. </param>
        /// <returns>Task of getting a vehicle. </returns>
        Task<Vehicle> FindById(string id);

        /// <summary>
        /// Rent a vehicle.
        /// </summary>
        /// <param name="bson">Vehicle.</param>
        /// <returns>Task of renting a vehicle.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the user already has an active rental.</exception>
        Task Rent(Vehicle bson);

        /// <summary>
        /// ReturnVehicle a vehicle.
        /// </summary>
        /// <param name="bson">Vehicle.</param>
        /// <returns>Task of returning a vehicle.</returns>
        Task ReturnVehicle(Vehicle bson);

        /// <summary>
        /// Find all available vehicles.
        /// </summary>
        /// <returns>Task of finding all available vehicles. </returns>
        /// <param name="fleetId">The identifier of the fleet.</param>
        Task<IEnumerable<Vehicle>> FindAllAvailable(string fleetId);
    }
}
