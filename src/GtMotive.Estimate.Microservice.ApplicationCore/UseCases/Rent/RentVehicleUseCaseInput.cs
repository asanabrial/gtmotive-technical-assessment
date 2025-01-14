namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent
{
    /// <summary>
    /// Represents the input of the AddVehicle use case.
    /// </summary>
    public class RentVehicleUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the rent user identifier.
        /// </summary>
        public string RentUserId { get; set; }
    }
}
