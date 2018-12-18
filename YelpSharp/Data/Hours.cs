using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpSharp.Data
{
    public class Hours
    {
        /// <summary>
        /// The type of the opening hours information. Right now, always return REGULAR.
        /// </summary>
        public string hours_type { get; set; }

        /// <summary>
        /// The detailed opening hours of each day in a week.
        /// </summary>
        public HoursOfDay[] open { get; set; }

        /// <summary>
        /// Whether the business is currently open or not.
        /// </summary>
        public bool is_open_now { get; set; }
    }

    public class HoursOfDay
    {
        /// <summary>
        /// Whether the business opens overnight or not. When this is true, the end time will be lower than the start time.
        /// </summary>
        public bool is_overnight { get; set; }

        /// <summary>
        /// Start of the opening hours in a day, in 24-hour clock (https://en.wikipedia.org/wiki/24-hour_clock) notation, like 1000 means 10 AM.
        /// </summary>
        public string start { get; set; }

        /// <summary>
        /// End of the opening hours in a day, in 24-hour clock (https://en.wikipedia.org/wiki/24-hour_clock) notation, like 2130 means 9:30 PM.
        /// </summary>
        public string end { get; set; }

        /// <summary>
        /// From 0 to 6, representing day of the week from Monday to Sunday. Notice that you may get the same day of the week more than once if the business has more than one opening time slots.
        /// </summary>
        public int day { get; set; }
    }
}
