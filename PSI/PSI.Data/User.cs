using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class User
    {
        public User()
        {
            UserInRole = new HashSet<UserInRole>();
        }

        public int Id { get; set; }
        public string AdUsername { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSystemAccount { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<UserInRole> UserInRole { get; set; }
    }
}
