using PSI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI.Service.interfaces
{
    public interface ITechService
    {
        List<Technician> GetAll();
        //void Add(User user);
        Technician Find(string email);
        List<Role> GetRoles(Technician tech);

    }
}
