using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data.Options
{
    /// <summary>
    /// Standard general search parameters
    /// </summary>
    public class GeneralOptions : BaseOptions
    {
        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        #region Properties

        /// <summary>
        /// Search term (e.g. "food", "restaurants"). If term isn't included we search everything.
        /// </summary>
        public string term { get; set; }

        /// <summary>
        /// Number of business results to return
        /// </summary>
        public int? limit { get; set; }

        /// <summary>
        /// Offset the list of returned business results by this amount
        /// </summary>
        public int? offset { get; set; }

        /// <summary>
        /// Sort mode: 0=Best matched (default), 1=Distance, 2=Highest Rated. If the mode is 1 or 2 a search may retrieve an additional 20 businesses past the initial limit of the first 20 results. This is done by specifying an offset and limit of 20. Sort by distance is only supported for a location or geographic search. The rating sort is not strictly sorted by the rating value, but by an adjusted rating value that takes into account the number of ratings, similar to a bayesian average. This is so a business with 1 rating of 5 stars doesn't immediately jump to the top.
        /// </summary>
        public int? sort { get; set; }

        /// <summary>
        /// Category to filter search results with. See the list of supported categories. The category filter can be a list of comma delimited categories. For example, 'bars,french' will filter by Bars and French. The category identifier should be used (for example 'discgolf', not 'Disc Golf').
        /// </summary>
        public string category_filter { get; set; }

        /// <summary>
        /// Search radius in meters. If the value is too large, a AREA_TOO_LARGE error may be returned. The max value is 25 miles.
        /// </summary>
        public double? radius_filter { get; set; }

        /// <summary>
        /// Whether to exclusively search for businesses with deals
        /// </summary>
        public bool? deals_filter { get; set; }

        #endregion

        //--------------------------------------------------------------------------
        //
        //	Methods
        //
        //--------------------------------------------------------------------------

        #region GetParameters

        /// <summary>
        /// format the properties for the querystring 
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetParameters()
        {
            var ps = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(term)) ps.Add("term", this.term);
            if (limit.HasValue) ps.Add("limit", this.limit.Value.ToString());
            if (limit.HasValue) ps.Add("offset", this.offset.Value.ToString());
            if (limit.HasValue) ps.Add("sort", this.sort.Value.ToString());
            if (!String.IsNullOrEmpty(category_filter)) ps.Add("category_filter", this.category_filter);
            if (radius_filter.HasValue) ps.Add("radius_filter", this.radius_filter.Value.ToString());
            if (deals_filter.HasValue) ps.Add("deals_filter", this.deals_filter.Value.ToString());            
            return ps;
        }

        #endregion
    }
}
