using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG102.Properties.App.Models;
using CPRG102.Properties.BLL;
using CPRG102.Properties.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG102.Properties.App.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult Index()
        {
            var model = RentalsManager.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new RentalViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(RentalProperty rental)
        {            
            try
            {
                RentalsManager.Add(rental);
                return Redirect("Index");
            }
            catch
            {
                return View();
            }            
        }
    }
}