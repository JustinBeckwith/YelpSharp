using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// customer reviews of the business
    /// </summary>
    public class Review
    {
        
        /// <summary>
        /// Review identifier
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Rating from 1-5
        /// </summary>
        public double rating { get; set; }

        /// <summary>
        /// URL to star rating image for this business (size = 84x17)
        /// </summary>
        public string rating_img_url { get; set; }

        /// <summary>
        /// URL to small version of rating image for this business (size = 50x10)
        /// </summary>
        public string rating_img_url_small { get; set; }

        /// <summary>
        /// url	URL to large version of rating image for this business (size = 166x30)
        /// </summary>
        public string rating_img_url_large { get; set; }

        /// <summary>
        /// Time created (Unix timestamp)
        /// </summary>
        public double time_created { get; set; }

        /// <summary>
        /// User who wrote the review
        /// </summary>
        public User user { get; set; }
       
     
       
    }
}
