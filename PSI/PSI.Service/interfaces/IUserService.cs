
using PSI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI.Service.interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        //void Add(User user);
        User Find(string email);
        List<Role> GetRoles(User user);

    }
}
