using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the make of the vehicle (Toyota, Ford, Honda...).
        /// </summary>
        [BsonElement("make")]
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        [BsonElement("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the year of the vehicle.
        /// </summary>
        [BsonElement("year")]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        [BsonElement("licensePlate")]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is available.
        /// </summary>
        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// Gets or sets the fleet identifier.
        /// </summary>
        [BsonElement("fleetId")]
        public string FleetId { get; set; }

        /// <summary>
        /// Gets or sets the rent user identifier.
        /// </summary>
        [BsonElement("rentUserId")]
        public string RentUserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the vehicle was created.
        /// </summary>
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Creates a new vehicle.
        /// </summary>
        /// <param name="make">Make of the vehicle. </param>
        /// <param name="model">Model of the vehicle. </param>
        /// <param name="year">Year of the vehicle.</param>
        /// <param name="licensePlate">License plate of the vehicle. </param>
        /// <param name="fleetId">Fleet identifier. </param>
        /// <returns>The new vehicle. </returns>
        /// <exception cref="ArgumentException">Year cannot be in the future. </exception>
        /// <exception cref="ArgumentException">License plate is required. </exception>
        public static Vehicle Create(string make, string model, int year, string licensePlate, string fleetId)
        {
            if (year > DateTime.UtcNow.Year)
            {
                throw new ArgumentException(ErrorMessage.InvalidVehicleYear.ToString());
            }

            ArgumentException.ThrowIfNullOrWhiteSpace(licensePlate);

            return new Vehicle
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Make = make,
                Model = model,
                Year = year,
                LicensePlate = licensePlate,
                IsAvailable = true,
                CreatedAt = DateTime.UtcNow,
                FleetId = fleetId
            };
        }

        /// <summary>
        /// Gets or sets the date when the vehicle was last updated.
        /// </summary>
        /// <param name="rentUserId">User identifier. </param>
        /// <exception cref="InvalidOperationException">Vehicle is not available for rent. </exception>
        public void Rent(string rentUserId)
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException(ErrorMessage.VehicleUnavailable.ToString());
            }

            IsAvailable = false;
            RentUserId = rentUserId;
        }

        /// <summary>
        /// Returns the vehicle.
        /// </summary>
        public void ReturnVehicle()
        {
            if (IsAvailable)
            {
                throw new InvalidOperationException(ErrorMessage.VehicleAlreadyReturned.ToString());
            }

            IsAvailable = true;
            RentUserId = null;
        }
    }
}
