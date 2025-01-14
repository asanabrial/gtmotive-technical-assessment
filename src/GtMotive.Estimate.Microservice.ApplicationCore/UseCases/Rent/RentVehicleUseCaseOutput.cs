using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent
{
    /// <summary>
    /// Represents the output of the AddVehicle use case.
    /// </summary>
    public class RentVehicleUseCaseOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the make of the vehicle (Toyota, Ford, Honda...).
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the year of the vehicle.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is available.
        /// </summary>
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// Gets or sets the fleet identifier.
        /// </summary>
        public string FleetId { get; set; }

        /// <summary>
        /// Gets or sets the date when the vehicle was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
