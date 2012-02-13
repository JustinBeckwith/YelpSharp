using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data.Options
{
    /// <summary>
    /// The geographic coordinate format is defined as:
    /// ll=latitude,longitude,accuracy,altitude,altitude_accuracy
    /// </summary>
    public class CoordinateOptions : LocationOptionBase
    {
        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        #region Properties

        /// <summary>
        /// Latitude of geo-point to search near (required)
        /// </summary>
        public double? latitude { get; set; }

        /// <summary>
        /// Longitude of geo-point to search near (required)
        /// </summary>
        public double? longitude { get; set; }

        /// <summary>
        /// Accuracy of latitude, longitude (optional)
        /// </summary>
        public double? accuracy { get; set; }

        /// <summary>
        /// Altitude (optional)
        /// </summary>
        public double? altitude { get; set; }

        /// <summary>
        /// Accuracy of altitude (optional)
        /// </summary>
        public double? altitude_accuracy { get; set; }

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
            return new Dictionary<string, string> {
                { 
                    "ll", string.Format("{0},{1},{2},{3},{4}", latitude, longitude, accuracy, altitude, altitude_accuracy)
                }
            };

        }

        #endregion
    }
}
