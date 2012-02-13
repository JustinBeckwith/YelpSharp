using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Data
{
    /// <summary>
    /// Center position of map bounds
    /// </summary>
	public class Coordinate
	{
        /// <summary>
        /// Latitude position of map bounds center
        /// </summary>
		public double latitude { get; set; }

        /// <summary>
        /// Longitude position of map bounds center
        /// </summary>
		public double longitude { get; set; }
	}
}
