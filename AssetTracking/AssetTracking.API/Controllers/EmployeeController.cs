using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetTracking.API.BLL;
using AssetTracking.API.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigin")]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employees = EmployeeManager.GetAll();
            return employees;
        }

        // GET: api/Employee/5
        [HttpGet("{employeeNumbers}", Name = "GetUnsigned")]
        public IEnumerable<Employee> GetUnsigned([FromBody] IEnumerable<string> employeeNumbers)
        {
            var employees = EmployeeManager.GetUnsigned(employeeNumbers);
            return employees;
        }

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
