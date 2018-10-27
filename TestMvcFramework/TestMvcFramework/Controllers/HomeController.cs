using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMvcFramework.Controllers
{
    [Route("/Home"), Route("/")]
    public class HomeController : Controller
    {
        [Route("/Index"), Route("")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Suppliers()
        {
            ViewBag.Message = "Your suppliers page.";

            return View();
        }

        ///Home/RouteNameTest/1/t
        [ActionName("RouteNameTest")]
        public ActionResult RouteTest(int id, string type)
        {
            ViewBag.Message = "This is a route test";
            return View("RouteTest");
        }
    }
}