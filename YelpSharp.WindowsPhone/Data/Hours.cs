using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpSharp.Data
{
    public class Hours
    {
        public string hours_type { get; set; }
        public HoursOfDay[] open { get; set; }
        public bool is_open_now { get; set; }
    }

    public class HoursOfDay
    {
        public bool is_overnight { get; set; }
        public string end { get; set; }
        public int day { get; set; }
        public string start { get; set; }
    }
}
