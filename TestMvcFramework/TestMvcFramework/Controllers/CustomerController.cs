using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcFramework.Models;

namespace TestMvcFramework.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            //call the model and pass to the view
            var custs = CustomerManager.GetAll();
            return View(custs);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var cust = CustomerManager.Get(id);
            return View(cust);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        //public ActionResult Create(Customer customer)
        public ActionResult Create(FormCollection collection)
        {
            try
            {                
                var cust = new Customer();
                cust.FirstName = collection["FirstName"];
                cust.LastName = collection["LastName"];
                cust.City = collection["City"];
                cust.Phone = collection["Phone"];
                CustomerManager.Add(cust);
                //CustomerManager.Add(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var cust = CustomerManager.Get(id);
            return View(cust);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
