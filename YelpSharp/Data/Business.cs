using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// information detailing a business
    /// </summary>
	public class Business : ApiResponse
	{
        /// <summary>
        /// Yelp ID for this business
        /// </summary>
		public string id { get; set;  }

        /// <summary>
        /// Name of this business
        /// </summary>
		public string name { get; set;  }

        /// <summary>
        /// URL of photo for this business
        /// </summary>
		public string image_url { get; set; }

        /// <summary>
        /// Whether business has been claimed by a business owner
        /// </summary>
        public bool is_claimed { get; set; }

        /// <summary>
        /// Whether business has been (permanently) closed
        /// </summary>
        public bool is_closed { get; set; }

        /// <summary>
        /// URL for business page on Yelp
        /// </summary>
		public string url { get; set; }

        /// <summary>
        /// How expensive the business is from $-$$$$
        /// </summary>
		public string price { get; set; }

        /// <summary>
        /// Rating for this business (value ranges from 1, 1.5, ... 4.5, 5)
        /// </summary>
		public double rating { get; set; }

        /// <summary>
        /// Number of reviews for this business
        /// </summary>
		public int review_count { get; set; }

        /// <summary>
        /// Phone number for this business with international dialing code (e.g. +442079460000)
        /// </summary>
		public string phone { get; set; }

        /// <summary>
        /// Phone number for this business to be displayed
        /// </summary>
		public string display_phone { get; set; }

        /// <summary>
        /// URLs of more photo for this business
        /// </summary>
		public string[] photos { get; set; }

        /// <summary>
        /// Hours of business
        /// </summary>
		public Hours[] hours { get; set; }

        /// <summary>
        /// Provides a list of category name, alias pairs that this business is associated with. For example, [["Local Flavor", "localflavor"], ["Active Life", "active"], ["Mass Media", "massmedia"]] The alias is provided so you can search with the category_filter.
        /// </summary>
		public Category[] categories { get; set;  }

        /// <summary>
        /// Coordinate data for this business
        /// </summary>
        public Coordinate coordinates { get; set; }

        /// <summary>
        /// Location data for this business
        /// </summary>
        public Location location { get; set; }

        /// <summary>
        /// Types of transactions made at business
        /// </summary>
		public string[] transactions { get; set; }
	}
}
