using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// Location data for this business
    /// </summary>
	public class Location
	{
        /// <summary>
        /// Coordinates for this business
        /// </summary>
        public Coordinate coordinate { get; set; }

        /// <summary>
        /// Address for this business. Only includes address fields.
        /// </summary>
		public string[] address { get; set; }

        /// <summary>
        /// Address for this business formatted for display. Includes all address fields, cross streets and city, state_code, etc.
        /// </summary>
		public string[] display_address { get; set;  }

        /// <summary>
        /// City for this business
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// ISO 3166-2 state code for this business (http://en.wikipedia.org/wiki/ISO_3166-2)
        /// </summary>
        public string state_code { get; set; }

        /// <summary>
        /// Postal code for this business (http://en.wikipedia.org/wiki/Postal_code)
        /// </summary>
        public string postal_code { get; set; }

        /// <summary>
        /// ISO 3166-1 country code for this business (http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
        /// </summary>
        public string country_code { get; set; }

        /// <summary>
        /// Cross streets for this business
        /// </summary>
        public string cross_streets { get; set; }

        /// <summary>
        /// List that provides neighborhood(s) information for business
        /// </summary>
        public string[] neighborhoods { get; set; }

        /// <summary>
        /// Contains a value that corresponds to the accuracy with which the latitude / longitude was determined in the geocoder. These correspond to Google's GGeoAddressAccuracy field. (http://code.google.com/apis/maps/documentation/javascript/v2/reference.html#GGeoAddressAccuracy)
        /// </summary>
        public double geo_accuracy { get; set; }
	}
}
