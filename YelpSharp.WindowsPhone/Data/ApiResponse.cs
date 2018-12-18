using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpSharp.Data
{
    public class ApiResponse
    {
        /// <summary>
        /// Only is returned at the base of an api response when an error occurs
        /// </summary>
        public ResponseError error { get; set; }
    }
    public class ResponseError
    {
        /// <summary>
        /// Error code
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// Long description of error that occurred
        /// </summary>
        public string description { get; set; }
    }

    public enum ErrorCode
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
