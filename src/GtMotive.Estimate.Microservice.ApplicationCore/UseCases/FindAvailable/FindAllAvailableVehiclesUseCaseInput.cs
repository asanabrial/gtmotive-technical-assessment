namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindAvailable
{
    /// <summary>
    /// Represents the input of the AddVehicle use case.
    /// </summary>
    public class FindAllAvailableVehiclesUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the fleet identifier.
        /// </summary>
        public string FleetId { get; set; }
    }
}
