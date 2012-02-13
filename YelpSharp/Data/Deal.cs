using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// Deal info for this business (optional: this field is present only if there's a Deal)
    /// </summary>
    public class Deal
    {
        /// <summary>
        /// Deal identifier
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Deal title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Deal url
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Deal image url
        /// </summary>
        public string image_url { get; set; }

        /// <summary>
        /// Currency code: http://en.wikipedia.org/wiki/ISO_4217
        /// </summary>
        public string currency_code { get; set; }

        /// <summary>
        /// Deal start time (Unix timestamp) http://unixtimesta.mp/
        /// </summary>
        public double time_start { get; set; }

        /// <summary>
        /// Deal end time (optional: this field is present only if the Deal ends)
        /// </summary>
        public double time_end { get; set; }

        /// <summary>
        /// Additional details for the Deal, separated by newlines
        /// </summary>
        public string what_you_get { get; set; }

        /// <summary>
        /// Important restrictions for the Deal, separated by newlines
        /// </summary>
        public string important_restrictions { get; set; }

        /// <summary>
        /// Deal additional restrictions
        /// </summary>
        public string additional_restrictions { get; set; }

        /// <summary>
        /// Deal options
        /// </summary>
        public List<DealOptions> options { get; set; }   
    }
}
