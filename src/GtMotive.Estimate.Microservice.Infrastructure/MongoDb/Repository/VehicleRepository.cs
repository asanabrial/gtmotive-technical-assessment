using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repository;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repository
{
    public class VehicleRepository(IUnitOfWork unitOfWork) : IVehicleRepository
    {
        public IMongoCollection<Vehicle> VehicleCollection { get; } = unitOfWork.Db.GetCollection<Vehicle>(nameof(Vehicle));

        /// <summary>
        /// Adds a vehicle to the database.
        /// </summary>
        /// <param name="bson">The vehicle to add.</param>
        /// <returns>Internal identifier of the vehicle.</returns>
        public async Task Add(Vehicle bson)
        {
            await VehicleCollection.InsertOneAsync(bson);
        }

        /// <summary>
        /// Get a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the vehicle.</param>
        /// <returns>The vehicle.</returns>
        public async Task<Vehicle> FindById(string id)
        {
            return await VehicleCollection.Find(v => v.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Rent a vehicle.
        /// </summary>
        /// <param name="bson">Vehicle.</param>
        /// <returns>Task of renting a vehicle.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the user already has an active rental.</exception>
        public async Task Rent(Vehicle bson)
        {
            var vehicleRentedByUser = await VehicleCollection.Find(v => v.RentUserId == bson.RentUserId).FirstOrDefaultAsync();

            if (vehicleRentedByUser != null)
            {
                throw new InvalidOperationException(ErrorMessage.UserAlreadyHasActiveRental.ToString());
            }

            await VehicleCollection.ReplaceOneAsync(v => v.Id == bson.Id, bson);
        }

        /// <summary>
        /// ReturnVehicle a vehicle.
        /// </summary>
        /// <param name="bson">Vehicle.</param>
        /// <returns>Task of returning a vehicle.</returns>
        public async Task ReturnVehicle(Vehicle bson)
        {
            await VehicleCollection.ReplaceOneAsync(v => v.Id == bson.Id, bson);
        }

        /// <summary>
        /// Find all available vehicles.
        /// </summary>
        /// <returns>The available vehicles.</returns>
        /// <param name="fleetId">Fleet identifier.</param>
        public async Task<IEnumerable<Vehicle>> FindAllAvailable(string fleetId)
        {
            var vehicles = await VehicleCollection
                .Find(v => v.IsAvailable && v.FleetId == fleetId).ToListAsync();
            return vehicles;
        }
    }
}
