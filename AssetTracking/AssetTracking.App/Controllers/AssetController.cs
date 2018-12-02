using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetTracking.App.Models;
using AssetTracking.BLL;
using AssetTracking.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracking.App.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public IActionResult GetAll()
        {
            var assets = AssetManager.GetAll();
            var assetList = assets.
                Select(a => new AssetListViewModel //convert to a ViewModel from RentalProperty
                {
                    Description = a.Description,
                    Type = a.AssetType.Name,
                    TagNumber = a.TagNumber,
                    SerialNumber = a.SerialNumber,
                    Empoyee = a.AssignedTo ?? "",
                    Department = a.AssignedTo == null ? "" : "something"
                });
            return View(assetList);
        }

        public IActionResult Index()
        {
            var filters = new AssetSearchViewModel();
            return View(filters);
        }
        public IActionResult GetAssetsByStatus(int status)
        {
            return ViewComponent("AssetsByStatus", status);
        }

        public IActionResult GetAssetsByEmployee(int id)
        {
            return ViewComponent("AssetsByEmployee", id);
        }
        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("GetAssetsByType", id);
        }

        // POST: Asset/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(int id, IFormCollection collection)
        {
            try
            {
                List<Asset> assets = new List<Asset>();
                assets.Add(new Asset
                {
                    Id = id,
                    AssignedTo = id.ToString()
                }
                );
                // TODO: Add update logic here                
                AssetManager.Assign(assets);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Asset/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            var model = new AssetAddViewModel();
            return View(model);
        }

        public ActionResult GetModelList(int id)
        {
            var list = new List<Model>();
            if(id == 0)
            {
                return Json(list);
            }
            list = ModelManger.GetAll().Where(m => m.ManufacturerId == id).ToList();
            return Json(list);
        }

        // POST: Asset/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asset asset)
        {
            try
            {
                // TODO: Add insert logic here
                AssetManager.Add(asset);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Asset/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asset/Edit/5
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

        // GET: Asset/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asset/Delete/5
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