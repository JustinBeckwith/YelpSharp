using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpSharp;

namespace PhoneSample
{
    class Config
    {
        #region GetOptions
        /// <summary>
        /// return the oauth options in this case from app.config
        /// </summary>
        /// <returns></returns>
        public static Options Options
        {
            get
            {
                throw new InvalidOperationException("Please open Config.cs and add your own keys for the YELP API");
                return new Options()
                {
                    AccessToken = "YOUR ACCESS TOKEN HERE",
                    AccessTokenSecret = "YOUR ACESS TOKEN SECRET HERE",
                    ConsumerKey = "YOUR CONSUMER KEY HERE",
                    ConsumerSecret = "YOUR CONSUMER SECRET HERE"
                };
            }
        }
        #endregion
    }
}
