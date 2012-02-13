using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// Suggested bounds in a map to display results in
    /// </summary>
	public class Region
	{
        /// <summary>
        /// Center position of map bounds
        /// </summary>
		public Coordinate center { get; set; }

        /// <summary>
        /// Span of suggested map bounds
        /// </summary>
		public Span span { get; set;  }		
	}
}
