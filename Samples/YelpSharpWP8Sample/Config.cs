using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpSharp;

namespace YelpSharpWP8Sample
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
                    _options = new Options
                    {
                        AppId = "YOUR_APP_ID",
                        AppSecret = "YOUR_APP_SECRET"
                    };

                    if (String.IsNullOrEmpty(_options.AppId) ||
                        String.IsNullOrEmpty(_options.AppSecret))
                    {
                        throw new InvalidOperationException("No OAuth info available.  Please modify Config.cs to add your YELP API OAuth keys");
                    }
                }
                return _options;
            }
        }
    }
}
