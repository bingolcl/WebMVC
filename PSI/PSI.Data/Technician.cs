using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class Technician
    {
        public Technician()
        {
            TechInRole = new HashSet<TechInRole>();
            Vacation = new HashSet<Vacation>();
        }

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string TechnicianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Province { get; set; }
        public string TimeZone { get; set; }
        public bool IsActive { get; set; }

        public virtual TimeZone TimeZoneNavigation { get; set; }
        public virtual ICollection<TechInRole> TechInRole { get; set; }
        public virtual ICollection<Vacation> Vacation { get; set; }
    }
}
