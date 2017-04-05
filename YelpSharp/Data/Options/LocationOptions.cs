using System;
using System.Collections.Generic;
using System.Globalization;

namespace YelpSharp.Data.Options
{
    /// <summary>
    /// Specify Location by Neighborhood, Address, or City
    /// Location is specified by a particular neighborhood, address or city.
    /// The location format is defined: ?location=location
    /// </summary>
    public class LocationOptions : LocationOptionBase
    {

        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        #region Properties

        /// <summary>
        /// Specifies the combination of "address, neighborhood, city, state or zip, optional country" to be used when searching for businesses. (required)
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// Latitude of geo-point to search near (required)
        /// </summary>
        public double? latitude { get; set; }

        /// <summary>
        /// Longitude of geo-point to search near (required)
        /// </summary>
        public double? longitude { get; set; }

        #endregion



        //--------------------------------------------------------------------------
        //
        //	Methods
        //
        //--------------------------------------------------------------------------

        #region GetParameters

        /// <summary>
        /// format the properties for the querystring 
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetParameters()
        {
            // location is a required field
            if ((String.IsNullOrEmpty(location) && !latitude.HasValue && !longitude.HasValue) ||
                (latitude.HasValue && !longitude.HasValue) ||
                (longitude.HasValue && !latitude.HasValue))
                throw new InvalidOperationException("To perform a location based search, the location or lat/lng must be set.  For coordinate based searches, use the lat/lng parameters.");

            var ps = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(location)) ps.Add("location", location);
            if (latitude.HasValue) ps.Add("latitude", latitude.Value.ToString(CultureInfo.InvariantCulture));
            if (longitude.HasValue) ps.Add("longitude", longitude.Value.ToString(CultureInfo.InvariantCulture));
            
            
            return ps;
        }

        #endregion
    }
}
