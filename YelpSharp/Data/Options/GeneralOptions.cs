using System;
using System.Collections.Generic;
using System.Globalization;
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

        /// <summary>
        /// Search term (e.g. "food", "restaurants"). If term isn't included we search everything.
        /// </summary>
        public string term { get; set; }

        /// <summary>
        /// Required if either latitude or longitude is not provided. Specifies the combination of "address, neighborhood, city, state or zip, optional country" to be used when searching for businesses.
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// Required if location is not provided. Latitude of the location you want to search near by.
        /// </summary>
        public decimal? latitude { get; set; }

        /// <summary>
        /// Required if location is not provided. Longitude of the location you want to search near by.
        /// </summary>
        public decimal? longitude { get; set; }

        /// <summary>
        /// Search radius in meters. If the value is too large, a AREA_TOO_LARGE error may be returned. The max value is 40000 meters (25 miles).
        /// </summary>
        public int? radius { get; set; }

        /// <summary>
        /// Categories to filter the search results with. See the list of supported categories. The category filter can be a list of comma delimited categories. For example, "bars,french" will filter by Bars and French. The category identifier should be used (for example "discgolf", not "Disc Golf").
        /// </summary>
        public string categories { get; set; }

        /// <summary>
        /// Number of business results to return. By default, it will return 20. Maximum is 50.
        /// </summary>
        public int? limit { get; set; }

        /// <summary>
        /// Offset the list of returned business results by this amount.
        /// </summary>
        public int? offset { get; set; }

        /// <summary>
        /// Sort the results by one of the these modes: best_match, rating, review_count or distance. By default it's best_match. The rating sort is not strictly sorted by the rating value, but by an adjusted rating value that takes into account the number of ratings, similar to a bayesian average. This is so a business with 1 rating of 5 stars doesn’t immediately jump to the top.
        /// </summary>
        public string sort_by { get; set; }

        /// <summary>
        /// Pricing levels to filter the search result with: 1 = $, 2 = $$, 3 = $$$, 4 = $$$$. The price filter can be a list of comma delimited pricing levels. For example, "1, 2, 3" will filter the results to show the ones that are $, $$, or $$$.
        /// </summary>
        public string price { get; set; }

        /// <summary>
        /// Default to false. When set to true, only return the businesses open now. Notice that open_at and open_now cannot be used together.
        /// </summary>
        public bool open_now { get; set; } = false;

        /// <summary>
        /// An integer represending the Unix time in the same timezone of the search location. If specified, it will return business open at the given time. Notice that open_at and open_now cannot be used together.
        /// </summary>
        public int? open_at { get; set; }

        /// <summary>
        /// Additional filters to restrict search results. Possible values are:
        ///  - hot_and_new - Hot and New businesses
        ///  - request_a_quote - Businesses that have the Request a Quote feature
        ///  - waitlist_reservation - Businesses that have an online waitlist
        ///  - cashback - Businesses that offer Cash Back
        ///  - deals - Businesses that offer Deals
        /// You can combine multiple attributes by providing a comma separated like "attribute1,attribute2". If multiple attributes are used, only businesses that satisfy ALL attributes will be returned in search results.For example, the attributes "hot_and_new,cashback" will return businesses that are Hot and New AND offer Cash Back.
        /// </summary>
        public string attributes { get; set; }

        //--------------------------------------------------------------------------
        //
        //	Methods
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// format the properties for the querystring 
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetParameters()
        {
            var ps = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(term)) ps.Add("term", term);
            if (!String.IsNullOrEmpty(location)) ps.Add("location", term);
            if (latitude.HasValue) ps.Add("latitude", latitude.Value.ToString(CultureInfo.InvariantCulture));
            if (longitude.HasValue) ps.Add("longitude", longitude.Value.ToString(CultureInfo.InvariantCulture));
            if (radius.HasValue) ps.Add("radius", radius.Value.ToString(CultureInfo.InvariantCulture));
            if (!String.IsNullOrEmpty(categories)) ps.Add("categories", categories);
            if (limit.HasValue) ps.Add("limit", limit.Value.ToString());
            if (offset.HasValue) ps.Add("offset", offset.Value.ToString());
            if (!String.IsNullOrEmpty(sort_by)) ps.Add("sort_by", sort_by);
            if (!String.IsNullOrEmpty(price)) ps.Add("price", price);
            if (open_now) ps.Add("open_now", "true");
            if (open_at.HasValue) ps.Add("open_at", open_at.Value.ToString());
            if (!String.IsNullOrEmpty(attributes)) ps.Add("attributes", attributes);          
            return ps;
        }
    }
}
