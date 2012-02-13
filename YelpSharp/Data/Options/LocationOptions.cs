using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// An optional latitude, longitude parameter can also be specified as a hint to the geocoder to disambiguate the location text.
        /// The format for this is defined as:   ?cll=latitude,longitude
        /// </summary>
        public CoordinateOptions coordinates { get; set; }

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
            var ps = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(location)) ps.Add("location", this.location);

            // if coordinates are specified add those to the parameters hash
            if (coordinates != null && coordinates.longitude.HasValue && coordinates.latitude.HasValue)
                ps.Add("cll", string.Format("{0},{1}", coordinates.latitude, coordinates.longitude));
            
            return ps;
        }

        #endregion
    }
}
