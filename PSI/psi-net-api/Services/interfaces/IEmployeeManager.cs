using psi_net_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Services.interfaces
{
    public interface IEmployeeManager
    {
        List<Employee> GetAll();
        void Add(Employee employee);
        Employee Find(int id);

    }
}
