using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YelpSharp.Util;

namespace YelpSharp.Data.Options
{
    /// <summary>
    /// Advanced search parameters
    /// </summary>
    public class SearchOptions : BaseOptions
    {
        #region Properties

        /// <summary>
        /// standard general search options (filters, terms, etc)
        /// </summary>
        public GeneralOptions GeneralOptions { get; set; }

        /// <summary>
        /// Results will be localized in the region format and language if supported.
        /// </summary>
        public LocaleOptions LocaleOptions { get; set; }

        /// <summary>
        /// location options (Location, Bounds, or Coordinate)
        /// </summary>
        public LocationOptionBase LocationOptions { get; set; }

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
            
            // apply all of the options to a single hash
            if (GeneralOptions != null)  ps = ps.MergeLeft(GeneralOptions.GetParameters());
            if (LocaleOptions != null) ps = ps.MergeLeft(LocaleOptions.GetParameters());
            if (LocationOptions != null) ps = ps.MergeLeft(LocationOptions.GetParameters());

            return ps;
        }

        #endregion
    }
}
