using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data.Options
{
    /// <summary>
    /// Location is specified by a bounding box, defined by a southwest latitude/longitude and a northeast latitude/longitude geographic coordinate.
    /// The bounding box format is defined as:
    /// bounds=sw_latitude,sw_longitude|ne_latitude,ne_longitude
    /// </summary>
    public class BoundOptions : LocationOptionBase
    {

        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        #region Properties

        /// <summary>
        /// Southwest latitude of bounding box
        /// </summary>
        public double? sw_latitude { get; set; }

        /// <summary>
        /// Southwest longitude of bounding box
        /// </summary>
        public double? sw_longitude { get; set; }

        /// <summary>
        /// Northeast latitude of bounding box
        /// </summary>
        public double? ne_latitude { get; set; }

        /// <summary>
        /// Northeast longitude of bounding box
        /// </summary>
        public double? ne_longitude { get; set; }

        #endregion

        //--------------------------------------------------------------------------
        //
        //	Methods
        //
        //--------------------------------------------------------------------------

        #region GetParameters

        /// <summary>
        /// format the properties for the querystring - bounds is a single querystring parameter
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string,string> {
                { 
                    "bounds", string.Format("{0},{1},{2},{3}", sw_latitude, sw_longitude, ne_latitude, ne_longitude)
                }
            };

        }

        #endregion



    }
}
