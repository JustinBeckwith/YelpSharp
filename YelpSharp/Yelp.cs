using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Globalization;

using Twitterizer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using YelpSharp.Data;


namespace YelpSharp
{
    /// <summary>
    /// 
    /// </summary>
	public class Yelp
	{
        //--------------------------------------------------------------------------
        //
        //	Variables
        //
        //--------------------------------------------------------------------------

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        protected const string rootUri = "http://api.yelp.com/v2/";

        /// <summary>
        /// 
        /// </summary>
		protected Options options { get; set; }

        #endregion

        //--------------------------------------------------------------------------
        //
        //	Constructors
        //
        //--------------------------------------------------------------------------

        #region Constructors

        public Yelp(Options options)
		{
			this.options = options;
		}

        #endregion

        //--------------------------------------------------------------------------
        //
        //	Public Methods
        //
        //--------------------------------------------------------------------------

        #region Search

        /// <summary>
        /// Simple search method to look for a term in a given plain text address
        /// </summary>
        /// <param name="term">what to look for (ex: coffee)</param>
        /// <param name="location">where to look for it (ex: seattle)</param>
        /// <returns>a strongly typed result</returns>
        public SearchResults Search(string term, string location)
		{
			var raw = makeRequest(new Dictionary<string, string>
				{
					{ "term", term },
					{ "location", location }
				});

            var results = JsonConvert.DeserializeObject<SearchResults>(raw);
            return results;
            
		}

        /// <summary>
        /// advanced search based on search options object
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public SearchResults Search(YelpSharp.Data.Options.SearchOptions options)
        {
            var raw = makeRequest(options.GetParameters());
            var results = JsonConvert.DeserializeObject<SearchResults>(raw);
            return results;
        }

        #endregion


        //--------------------------------------------------------------------------
        //
        //	Internal Methods
        //
        //--------------------------------------------------------------------------

        #region makeRequest
        /// <summary>
        /// contains all of the oauth magic, makes the http request and returns raw json
        /// </summary>
        /// <param name="parameters">hash array of qs parameters</param>
        /// <returns>plain text json response from the api</returns>
        protected string makeRequest(Dictionary<string, string> parameters)
		{
			// build the url with parameters
			var url = "http://api.yelp.com/v2/search";
			var firstp = true;
			foreach(var p in parameters) {
				url += firstp ? "?" : "&";
				firstp = false;
				url += p.Key + "=" + HttpUtility.UrlEncode(p.Value);
			}			

			// generate the access token
			var ot = new OAuthTokens();
			ot.AccessToken = options.AccessToken;
			ot.AccessTokenSecret = options.AccessTokenSecret;
			ot.ConsumerKey = options.ConsumerKey;
			ot.ConsumerSecret = options.ConsumerSecret;

			// make the request 
			var formattedUri = String.Format(CultureInfo.InvariantCulture, url, "");
			var uri = new Uri(formattedUri);
			var wb = new WebRequestBuilder(uri, HTTPVerb.GET, ot);
			var wr = wb.ExecuteRequest();
			var sr = new StreamReader(wr.GetResponseStream());			
			var data =  sr.ReadToEnd();

            return data;
        }
        #endregion


    }
}
