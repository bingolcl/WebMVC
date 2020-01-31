using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class TimeZone
    {
        public TimeZone()
        {
            Technician = new HashSet<Technician>();
        }

        public string TimeZoneTag { get; set; }
        public string TimeZoneDescription { get; set; }
        public int GmtOffsetHours { get; set; }

        public virtual ICollection<Technician> Technician { get; set; }
    }
}
