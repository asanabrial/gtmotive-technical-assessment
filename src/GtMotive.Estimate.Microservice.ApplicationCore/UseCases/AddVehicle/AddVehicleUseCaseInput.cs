namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle
{
    /// <summary>
    /// Represents the input of the AddVehicle use case.
    /// </summary>
    public class AddVehicleUseCaseInput : IUseCaseInput
    {
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
        /// Gets or sets the fleet identifier.
        /// </summary>
        public string FleetId { get; set; }
    }
}
