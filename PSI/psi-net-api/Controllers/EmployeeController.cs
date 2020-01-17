using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psi_net_api.Models;
using psi_net_api.Services.interfaces;

namespace psi_net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigin")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeManager EmployeeManager { get; set; }
        IUserManager UserManager { get; set; }

        public EmployeeController(IEmployeeManager employeeManager, IUserManager userManager)
        {
            EmployeeManager = employeeManager;
            UserManager = userManager;
        }
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employees = EmployeeManager.GetAll();
            return employees;
        }

        

        //// GET: api/Employee/5
        //[HttpGet("{employeeNumbers}", Name = "GetUnsigned")]
        //public IEnumerable<Employee> GetUnsigned([FromBody] IEnumerable<string> employeeNumbers)
        //{
        //    var employees = EmployeeManager.GetUnsigned(employeeNumbers);
        //    return employees;
        //}

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}