using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// information detailing a business
    /// </summary>
	public class Business
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
		public string image_url { get; set;  }

        /// <summary>
        /// URL for business page on Yelp
        /// </summary>
		public string url { get; set; }

        /// <summary>
        /// URL for mobile business page on Yelp
        /// </summary>
		public string mobile_url { get; set; }

        /// <summary>
        /// Phone number for this business with international dialing code (e.g. +442079460000)
        /// </summary>
		public string phone { get; set;  }

        /// <summary>
        /// Phone number for this business formatted for display
        /// </summary>
		public string display_phone { get; set;  }

        /// <summary>
        /// Number of reviews for this business
        /// </summary>
		public int review_count { get; set;  }

        /// <summary>
        /// Provides a list of category name, alias pairs that this business is associated with. For example, [["Local Flavor", "localflavor"], ["Active Life", "active"], ["Mass Media", "massmedia"]] The alias is provided so you can search with the category_filter.
        /// </summary>
		public string [][] categories { get; set;  }

        /// <summary>
        /// Distance that business is from search location in meters, if a latitude/longitude is specified.
        /// </summary>
		public double distance { get; set;  }

        /// <summary>
        /// Rating for this business (value ranges from 1, 1.5, ... 4.5, 5)
        /// </summary>
		public double rating { get; set;  }

        /// <summary>
        /// URL to star rating image for this business (size = 84x17)
        /// </summary>
		public string rating_img_url { get; set;  }

        /// <summary>
        /// URL to small version of rating image for this business (size = 50x10)
        /// </summary>
		public string rating_img_url_small { get; set; }

        /// <summary>
        /// URL to large version of rating image for this business (size = 166x30)
        /// </summary>
		public string rating_img_url_large { get; set; }

        /// <summary>
        /// Snippet text associated with this business
        /// </summary>
		public string snippet_text { get; set;  }

        /// <summary>
        /// URL of snippet image associated with this business
        /// </summary>
		public string snippet_image_url { get; set;  }

        /// <summary>
        /// Location data for this business
        /// </summary>
        public Location location { get; set; }

        /// <summary>
        /// list of deals for this business (optional: this field is present only if there's a Deal)
        /// </summary>
        public List<Deal> deals { get; set; }

        /// <summary>
        /// Whether business has been claimed by a business owner
        /// </summary>
        public bool is_claimed { get; set; }

        /// <summary>
        /// Whether business has been (permanently) closed
        /// </summary>
        public bool is_closed { get; set; }

        /// <summary>
        /// List of up to 3 review snippets for the business
        /// </summary>
        public List<Review> reviews { get; set; }
	}
}
