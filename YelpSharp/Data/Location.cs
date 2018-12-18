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
        /// Address line 1 for this business. Only includes address fields.
        /// </summary>
		public string address1 { get; set; }

        /// <summary>
        /// Address line 2 for this business. Only includes address fields.
        /// </summary>
		public string address2 { get; set; }
        /// <summary>
        /// 
        /// Address line 3 for this business. Only includes address fields.
        /// </summary>
		public string address3 { get; set; }

        /// <summary>
        /// City for this business
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// ISO 3166-2 state code for this business (http://en.wikipedia.org/wiki/ISO_3166-2)
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// Postal code for this business (http://en.wikipedia.org/wiki/Postal_code)
        /// </summary>
        public string zip_code { get; set; }

        /// <summary>
        /// ISO 3166-1 country code for this business (http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// Address for this business formatted for display. Includes all address fields, cross streets and city, state_code, etc.
        /// </summary>
		public string[] display_address { get; set;  }

        /// <summary>
        /// Cross streets for this business
        /// </summary>
        public string cross_streets { get; set; }
	}
}
