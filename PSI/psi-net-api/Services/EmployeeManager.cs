using Microsoft.EntityFrameworkCore;
using psi_net_api.Models;
using psi_net_api.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Services
{
    public class EmployeeManager : IEmployeeManager
    {
        PSIContext _psiContext { get; set; }

        public EmployeeManager(PSIContext context)
        {
            _psiContext = context;
        }

        public List<Employee> GetAll()
        {
            var employees = _psiContext.Employee.
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
            _psiContext.Employee.Add(employee);
            _psiContext.SaveChanges();
        }

        public Employee Find(int id)
        {
            var employee = _psiContext.Employee.Find(id);
            return employee;
        }
    }
}
