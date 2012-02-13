using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
	public class Span
	{
        /// <summary>
        /// Latitude width of map bounds
        /// </summary>
		public double latitude_delta { get; set; }

        /// <summary>
        /// Longitude height of map bounds
        /// </summary>
		public double longitude_delta { get; set; }
	}
}
