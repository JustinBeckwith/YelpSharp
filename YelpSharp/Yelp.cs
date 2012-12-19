using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using YelpSharp.Data;
using YelpSharp.Data.Options;


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
        public SearchResults Search(SearchOptions options)
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
                string[] keys = parameters.Keys.ToArray();
                foreach (string k in keys)
                {
                    // Rather than failing we could either remove the '+'...
                    //parameters[k] = parameters[k].Replace("+", "");

                    // or throw if passed
                    //if (parameters[k].Contains('+'))
                    //{
                    //    throw new InvalidOperationException("Yelp does not allow parameter values to contain the '+' character.");
                    //}

                    url += firstp ? "?" : "&";
                    firstp = false;
                    //Double URL encode "&" to prevent restsharp from treating the second half of the string as a new parameter
                    parameters[k] = parameters[k].Replace("&", "%26");
                    url += k + "=" + HttpUtility.UrlEncode(parameters[k]);
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
