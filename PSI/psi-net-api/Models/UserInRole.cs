using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Models
{
    public partial class UserInRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        //navigation properties
        public User User { get; set; }
        public Role Role { get; set; }

    }
}
