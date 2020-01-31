using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class Vacation
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public DateTime Date { get; set; }

        public virtual Technician Technician { get; set; }
    }
}
