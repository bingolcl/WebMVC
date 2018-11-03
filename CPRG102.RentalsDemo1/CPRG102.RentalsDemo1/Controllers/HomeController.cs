using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG102.Rentals.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPRG102.RentalsDemo1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var rentals = PropertyManager.Rentals;
            return View(rentals);
        }

        public IActionResult AddProperty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Process(RentalProperty rental)
        {
            PropertyManager.AddRental(rental);
            return Redirect("Index");
        }
    }
}