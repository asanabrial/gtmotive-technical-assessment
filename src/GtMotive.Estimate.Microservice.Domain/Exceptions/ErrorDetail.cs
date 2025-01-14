namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Error detail.
    /// </summary>
    public class ErrorDetail(string code, string message)
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string Code { get; } = code;

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; } = message;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object. </returns>
        public override string ToString() => $"Code: {Code}, Message: {Message}";
    }
}
