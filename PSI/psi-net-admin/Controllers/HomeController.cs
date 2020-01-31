using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSI.Service.interfaces;
using psi_net_admin.Models;

namespace psi_net_admin.Controllers
{
    public class HomeController : Controller
    {
        ITechService TechService { get; set; }
        public HomeController(ITechService service)
        {
            TechService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllTech()
        {
            var techs = TechService.GetAll();
            return View(techs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
