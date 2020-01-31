using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class TechInRole
    {
        public int TechnicianId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Technician Technician { get; set; }
    }
}
