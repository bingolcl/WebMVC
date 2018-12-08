using AssetTracking.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking.API.BLL.interfaces
{
    public interface IEmployeeManager
    {
        List<Employee> GetAll();
        void Add(Employee employee);
        Employee Find(int id);

    }
}
