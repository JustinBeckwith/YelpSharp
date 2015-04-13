using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using YelpSharp.Data;
using YelpSharp.Data.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;


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

        /// <summary>
        /// Root url for the Yelp REST API.
        /// </summary>
        protected const string rootUri = "http://api.yelp.com/v2/";

        /// <summary>
        /// Authentication options for the connection.
        /// </summary>
        protected Options options { get; set; }

        //--------------------------------------------------------------------------
        //
        //	Constructors
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// Driver for the Yelp API
        /// </summary>
        /// <param name="options">OAuth options for using the Yelp API</param>
        public Yelp(Options options)
        {
            this.options = options;
        }


        //--------------------------------------------------------------------------
        //
        //	Public Methods
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// Simple search method to look for a term in a given plain text address
        /// </summary>
        /// <param name="term">what to look for (ex: coffee)</param>
        /// <param name="location">where to look for it (ex: seattle)</param>
        /// <returns>a strongly typed result</returns>
        public Task<SearchResults> Search(string term, string location)
        {
            var result = makeRequest<SearchResults>("search", null, new Dictionary<string, string>
                {
                    { "term", term },
                    { "location", location }
                });

            return result;
        }

        /// <summary>
        /// advanced search based on search options object
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<SearchResults> Search(SearchOptions options)
        {
            var result = makeRequest<SearchResults>("search", null, options.GetParameters());
            return result;
        }

        /// <summary>
        /// search the list of business based on name
        /// </summary>
        /// <param name="name">name of the business you want to get information on</param>
        /// <returns>Business details</returns>
        public Task<Business> GetBusiness(string name)
        {
            var result = makeRequest<Business>("business", name, null);
            return result;
        }

        /// <summary>
        /// search businesses based on phone number
        /// </summary>
        /// <param name="phone">phone number of the business you want to get information on</param>
        /// <returns>List of matching businesses</returns>
        public Task<SearchResults> SearchByPhone(string phone)
        {
            var parameters = new Dictionary<string, string>()
            { 
                {"phone", phone} 
            };
            var result = makeRequest<SearchResults>("phone_search", null, parameters);
            return result;
        }

        //--------------------------------------------------------------------------
        //
        //	Internal Methods
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// contains all of the oauth magic, makes the http request and returns raw json
        /// </summary>
        /// <param name="parameters">hash array of qs parameters</param>
        /// <returns>plain text json response from the api</returns>
        protected Task<T> makeRequest<T>(string area, string id, Dictionary<string, string> parameters)
        {
            // build the url with parameters
            var url = area;
            if (!String.IsNullOrEmpty(id)) url += "/" + Uri.EscapeDataString(id);

            // restsharp FTW!
            var client = new RestClient(rootUri);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(options.ConsumerKey, options.ConsumerSecret, options.AccessToken, options.AccessTokenSecret);
            var request = new RestRequest(url, Method.GET);

            if (parameters != null)
            {
                string[] keys = parameters.Keys.ToArray();
                foreach (string k in keys)
                {
                    request.AddParameter(k, parameters[k]);
                }
            }

            var tcs = new TaskCompletionSource<T>();
            var handle = client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    tcs.SetResult(default(T));
                }
                else
                {
                    try
                    {
                        T results = JsonConvert.DeserializeObject<T>(response.Content);
                        tcs.SetResult(results);
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                }
            });

            return tcs.Task;
        }

    }
}
