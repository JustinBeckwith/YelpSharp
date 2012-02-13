using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// general search results data after calling the search api
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// The list of business entries (see http://www.yelp.com/developers/documentation/v2/search_api#business)
        /// </summary>
        public List<Business> businesses { get; set; }

        /// <summary>
        /// Suggested bounds in a map to display results in
        /// </summary>
        public Region region { get; set; }

        /// <summary>
        /// Total number of business results
        /// </summary>
        public int total { get; set; }
    }
}
