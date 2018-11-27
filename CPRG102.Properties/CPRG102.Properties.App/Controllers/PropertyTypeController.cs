using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG102.Properties.BLL;
using CPRG102.Properties.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPRG102.Properties.App.Controllers
{
    public class PropertyTypeController : Controller
    {
        // GET: PropertyType
        public ActionResult Index()
        {
            var types = PropertyTypeManager.GetAll();
            return View(types);
        }

        // GET: PropertyType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PropertyType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyType type)
        {
            try
            {
                // TODO: Add insert logic here
                //var style = collection["Style"];
                PropertyTypeManager.Add(type);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PropertyType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PropertyType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}