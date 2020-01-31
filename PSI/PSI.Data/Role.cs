using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class Role
    {
        public Role()
        {
            TechInRole = new HashSet<TechInRole>();
            UserInRole = new HashSet<UserInRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<TechInRole> TechInRole { get; set; }
        public virtual ICollection<UserInRole> UserInRole { get; set; }
    }
}
