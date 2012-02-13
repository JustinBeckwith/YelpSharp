using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// user on yelp
    /// </summary>
    public class User
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// User profile image url
        /// </summary>
        public string image_url { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string name { get; set; }
    }
}
