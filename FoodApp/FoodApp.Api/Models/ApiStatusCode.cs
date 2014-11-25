namespace FoodApp.Api.Models
{
    /// <summary>
    ///     The api status code.
    /// </summary>
    public enum ApiStatusCode
    {
        /// <summary>
        ///     The ok.
        /// </summary>
        Ok = 1000,

        /// <summary>
        ///     The authenticated.
        /// </summary>
        Authenticated = 1001,

        /// <summary>
        ///     The not found.
        /// </summary>
        NotFound = 1002,

        /// <summary>
        ///     The internal server error.
        /// </summary>
        InternalServerError = 1003,

        /// <summary>
        ///     The bad request.
        /// </summary>
        BadRequest = 1004,

        /// <summary>
        ///     The failed.
        /// </summary>
        Failed = 1005,

        /// <summary>
        ///     The Is suspended.
        /// </summary>
        IsSuspended = 1007,
    }
}