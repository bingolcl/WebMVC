using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG102.Properties.BLL;
using CPRG102.Properties.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPRG102.Properties.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigin")]
    public class PropertyTypeController : ControllerBase
    {
        // GET: api/PropertyType
        [HttpGet]
        public IEnumerable<PropertyType> Get()
        {
            var types = PropertyTypeManager.GetAll();
            return types;
        }

        // GET: api/PropertyType/5
        [HttpGet("{id}", Name = "Get")]
        public PropertyType Get(int id)
        {
            var type = PropertyTypeManager.Find(id);
            return type;
        }

        // POST: api/PropertyType
        [HttpPost]
        public void Post([FromBody] string style)
        {
            var pt = new PropertyType()
            {
                Style = style
            };
            PropertyTypeManager.Add(pt);
        }

        // PUT: api/PropertyType/5
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
