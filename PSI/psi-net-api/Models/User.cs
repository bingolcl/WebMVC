using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Models
{
    public partial class User
    {

        public int Id { get; set; }
        public string AdUsername { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSystemAccount { get; set; }
        public bool IsActive { get; set; }

        //navigation property
        public ICollection<UserInRole> UserRoles { get; set; }
    }
}
