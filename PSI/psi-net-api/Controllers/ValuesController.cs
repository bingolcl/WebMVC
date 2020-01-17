using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace psi_net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Gets two values.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Gets a value.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Posts a value.
        /// </summary>
        /// <param name="value">The value !!</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// Puts a value.
        /// </summary>
        /// <param name="id">The id !!</param>
        /// <param name="value">The value !!</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Deletes an entry.
        /// </summary>
        /// <param name="id">The id !!</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
