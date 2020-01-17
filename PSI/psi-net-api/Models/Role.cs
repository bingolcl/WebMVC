using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //navigation property
        public ICollection<UserInRole> UserRoles { get; set; }

    }
}
