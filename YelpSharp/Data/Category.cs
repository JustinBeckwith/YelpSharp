using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    public class Category
    {
        /// <summary>
        /// Shortname of category
        /// </summary>
        public string alias { get; set; }

        /// <summary>
        /// Full name of category
        /// </summary>
        public string title { get; set; }
    }
}
