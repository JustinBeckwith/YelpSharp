using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpSharp;

namespace YelpSharpTests
{
    class Config
    {
        private static Options _options;

        /// <summary>
        /// return the oauth options for using the Yelp API.  I store my keys in the environment settings, but you
        /// can just write them out here, or put them into an app.config file.  For more info, visit
        /// http://www.yelp.com/developers/getting_started/api_access
        /// </summary>
        /// <returns></returns>
        public static Options Options
        {
            get
            {
                if (_options == null)
                {                                        
                    // get all of the options out of EnvironmentSettings.  You can easily just put your own keys in here without
                    // doing the env dance, if you so choose
                    _options = new Options()
                    {
                        AccessToken = Environment.GetEnvironmentVariable("YELP_ACCESS_TOKEN", EnvironmentVariableTarget.Machine),
                        AccessTokenSecret = Environment.GetEnvironmentVariable("YELP_ACCESS_TOKEN_SECRET", EnvironmentVariableTarget.Machine),
                        ConsumerKey = Environment.GetEnvironmentVariable("YELP_CONSUMER_KEY", EnvironmentVariableTarget.Machine),
                        ConsumerSecret = Environment.GetEnvironmentVariable("YELP_CONSUMER_SECRET", EnvironmentVariableTarget.Machine)
                    };

                    if (String.IsNullOrEmpty(_options.AccessToken) ||
                        String.IsNullOrEmpty(_options.AccessTokenSecret) ||
                        String.IsNullOrEmpty(_options.ConsumerKey) ||
                        String.IsNullOrEmpty(_options.ConsumerSecret))
                    {
                        throw new InvalidOperationException("No OAuth info available.  Please modify Config.cs to add your YELP API OAuth keys");
                    }
                }
                return _options;
            }
        }        
    }
}
