using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindById
{
    /// <summary>
    /// Represents the input of the AddVehicle use case.
    /// </summary>
    public class FindVehicleUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Required]
        public string Id { get; set; }
    }
}
