using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// Deal options
    /// </summary>
    public class DealOptions
    {
        /// <summary>
        /// Deal option title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Deal option url for purchase
        /// </summary>
        public string purchase_url { get; set; }

        /// <summary>
        /// Deal option price (in cents)
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// Deal option price (formatted, e.g. "$6")
        /// </summary>
        public string formatted_price { get; set; }

        /// <summary>
        /// Deal option original price (in cents)
        /// </summary>
        public double original_price { get; set; }

        /// <summary>
        /// Deal option original price (formatted, e.g. "$12")
        /// </summary>
        public string formatted_original_price { get; set; }

        /// <summary>
        /// Whether the deal option is limited or unlimited
        /// </summary>
        public bool is_quantity_limited { get; set; }

        /// <summary>
        /// The remaining deal options available for purchase (optional: this field is only present if the deal is limited)
        /// </summary>
        public double remaining_count { get; set; }
    }
}
