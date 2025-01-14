namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Error messages.
    /// </summary>
    public static class ErrorMessage
    {
        /// <summary>
        /// Vehicle not found.
        /// </summary>
        public static readonly ErrorDetail VehicleNotFound = new("ERR_VEHICLE_NOT_FOUND", "Vehicle not found.");

        /// <summary>
        /// User already has an active rental.
        /// </summary>
        public static readonly ErrorDetail UserAlreadyHasActiveRental = new("ERR_USER_ACTIVE_RENTAL", "User already has an active rental.");

        /// <summary>
        /// Vehicle unavailable.
        /// </summary>
        public static readonly ErrorDetail VehicleUnavailable = new("ERR_VEHICLE_UNAVAILABLE", "Vehicle is not available for rent.");

        /// <summary>
        /// Vehicle already returned.
        /// </summary>
        public static readonly ErrorDetail VehicleAlreadyReturned = new("ERR_VEHICLE_ALREADY_RETURNED", "Vehicle is already returned.");

        /// <summary>
        /// Invalid vehicle year.
        /// </summary>
        public static readonly ErrorDetail InvalidVehicleYear = new("ERR_INVALID_YEAR", "Year cannot be in the future.");
    }
}
