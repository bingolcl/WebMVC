using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllerDemo.Models;

namespace ControllerDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
		
		public IActionResult Customer(int id)
        {
			var cust1 = new Customer
			{
				Id=1, FirstName = "John", LastName = "Doe", City="Calgary", Phone="403-555-1234"				
			};
			var cust2 = new Customer
			{
				Id=2, FirstName = "Jane", LastName = "Smith", City="Calgary", Phone="403-555-1234"				
			};
			var cust3 = new Customer
			{
				Id=3, FirstName = "Ken", LastName = "Know", City="Calgary", Phone="403-555-1234"				
			};
			
			var customers = new List<Customer>{cust1,cust2,cust3};
			
			var cust = customers.SingleOrDefault(c => c.Id == id);
			
            return Json(cust);
        }
		public IActionResult Greeting()
        {
            return Content("Hi There!");
        }
		
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
