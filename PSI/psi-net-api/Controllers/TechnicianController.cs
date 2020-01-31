using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI.Data;
using PSI.Service.interfaces;

namespace psi_net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        ITechService _techService { get; set; }

        public TechnicianController(ITechService techService)
        {
            _techService = techService;
        }

        [HttpGet]
        [Route("GetPSITechs")]
        public IEnumerable<Technician> GetPSITechs()
        {
            var techs = _techService.GetAll();
            return techs;
        }
    }
}
