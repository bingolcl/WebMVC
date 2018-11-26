using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracking.App.Controllers
{
    public class AssetTypeController : Controller
    {
        // GET: AssetType
        public ActionResult Index()
        {
            return View();
        }       


        // GET: AssetType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssetType/Edit/5
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

        // GET: AssetType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}