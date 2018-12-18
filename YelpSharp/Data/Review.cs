using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    public class Reviews : ApiResponse
    {
        public Review[] reviews { get; set; }
        public int total { get; set; }
    }

    /// <summary>
    /// customer reviews of the business
    /// </summary>
    public class Review
    {

        /// <summary>
        /// Rating from 1-5
        /// </summary>
        public double rating { get; set; }

        /// <summary>
        /// User who wrote the review
        /// </summary>
        public User user { get; set; }

        /// <summary>
        /// Text of the review
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Time of the review
        /// </summary>
        public DateTime time_created { get; set; }

        /// <summary>
        /// Url of the review
        /// </summary>
        public string url { get; set; }
       
    }
}
