using psi_net_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Services.interfaces
{
    public interface IUserManager
    {
        List<User> GetAll();
        //void Add(User user);
        User Find(string email);
        List<Role> GetRoles(User user);

    }
}
