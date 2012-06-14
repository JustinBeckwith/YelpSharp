
namespace YelpSharp.Data
{
    /// <summary>
    /// general error result data after calling the search api
    /// </summary>
    public class SearchError
    {
        /// <summary>
        /// Short description of error
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// Enum of possible error id's
        /// </summary>
        public ErrorId id { get; set; }
        /// <summary>
        /// Lengthier version of text, null for some errors
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Field with error, null for some errors
        /// </summary>
        public string field { get; set; }
    }

    public enum ErrorId
    {
        INTERNAL_ERROR,
        EXCEEDED_REQS,
        MISSING_PARAMETER,
        INVALID_PARAMETER,
        INVALID_SIGNATURE,
        INVALID_CREDENTIALS,
        INVALID_OAUTH_CREDENTIALS,
        ACCOUNT_UNCONFIRMED,
        PASSWORD_TOO_LONG,
        UNAVAILABLE_FOR_LOCATION,
        AREA_TOO_LARGE,
        MULTIPLE_LOCATIONS,
        BUSINESS_UNAVAILABLE,
        UNSPECIFIED_LOCATION
    }
}
