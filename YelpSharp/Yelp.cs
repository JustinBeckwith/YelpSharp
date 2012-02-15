using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Globalization;

//using Twitterizer;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;

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

        /// <summary>
        /// Driver for the Yelp API
        /// </summary>
        /// <param name="options">OAuth options for using the Yelp API</param>
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
			var raw = makeRequest("search", null, new Dictionary<string, string>
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
            var raw = makeRequest("search", null, options.GetParameters());
            var results = JsonConvert.DeserializeObject<SearchResults>(raw);
            return results;
        }

        #endregion


        #region GetBusiness
        /// <summary>
        /// search the list of business based on name
        /// </summary>
        /// <param name="name">name of the business you want to get information on</param>
        /// <returns>Business details</returns>
        public Business GetBusiness(string name)
        {
            var raw = makeRequest("business", name, null);
            var results = JsonConvert.DeserializeObject<Business>(raw);
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
        protected string makeRequest(string area, string id, Dictionary<string, string> parameters)
		{
			// build the url with parameters
			var url = area;
            if (!String.IsNullOrEmpty(id)) url += "/" + HttpUtility.UrlEncode(id);

            if (parameters != null)
            {
                var firstp = true;
                foreach (var p in parameters)
                {
                    url += firstp ? "?" : "&";
                    firstp = false;
                    url += p.Key + "=" + HttpUtility.UrlEncode(p.Value);
                }
            }
            
            // restsharp FTW!
            var client = new RestClient(rootUri);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(options.ConsumerKey, options.ConsumerSecret, options.AccessToken, options.AccessTokenSecret);
            var request = new RestRequest(url, Method.GET);
            var response = client.Execute(request);
            return response.Content;
        }
        #endregion


    }
}
