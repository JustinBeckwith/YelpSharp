using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data.Options
{
    /// <summary>
    /// options for locale
    /// </summary>
    public class LocaleOptions : BaseOptions
    {
        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        #region Properties

        /// <summary>
        /// ISO 3166-1 alpha-2 country code. Default country to use when parsing the location field. United States = US, Canada = CA, United Kingdom = GB (not UK).
        /// </summary>
        public string cc { get; set; }

        /// <summary>
        /// ISO 639 language code (default=en). Reviews written in the specified language will be shown.
        /// </summary>
        public string lang { get; set; }

        #endregion

        //--------------------------------------------------------------------------
        //
        //	Methods
        //
        //--------------------------------------------------------------------------

        #region GetParameters

        /// <summary>
        /// format the properties for the querystring - bounds is a single querystring parameter
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetParameters()
        {
            var ps = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(cc)) ps.Add("cc", this.cc);
            if (!String.IsNullOrEmpty(lang)) ps.Add("lang", this.lang);
            return ps;
        }

        #endregion
    }
}
