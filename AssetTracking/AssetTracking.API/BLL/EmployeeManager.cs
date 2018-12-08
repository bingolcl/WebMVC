using AssetTracking.API.BLL.interfaces;
using AssetTracking.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking.API.BLL
{
    public class EmployeeManager:IEmployeeManager
    {
        HRContext _hrContext { get; set; }

        public EmployeeManager(HRContext context)
        {
            _hrContext = context;
        }

        public List<Employee> GetAll()
        {
            var employees = _hrContext.Employee.
                            Include(e => e.Department).
                            ToList();
            return employees;
        }
        //public static List<Employee> GetUnsigned(IEnumerable<string> employeeNumbers)
        //{
        //    var employees = _hrContext.Employee.Where(e => !employeeNumbers.Any(es => es == e.EmployeeNumber)).
        //                    ToList();
        //    return employees;
        //}
        public void Add(Employee employee)
        {
            _hrContext.Employee.Add(employee);
            _hrContext.SaveChanges();
        }

        public Employee Find(int id)
        {
            var employee = _hrContext.Employee.Find(id);
            return employee;
        }
    }
}
