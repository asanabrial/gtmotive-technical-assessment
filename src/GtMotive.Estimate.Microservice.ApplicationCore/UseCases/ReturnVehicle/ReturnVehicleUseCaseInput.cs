namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Represents the input of the rent vehicle use case.
    /// </summary>
    public class ReturnVehicleUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }
    }
}
