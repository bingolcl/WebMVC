using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AssetTracking.App.Models;
using AssetTracking.BLL;
using AssetTracking.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using AssetTracking.BLL.interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetTracking.App.Controllers
{
    public class AssetController : Controller
    {
        IAssetManager AssetManager { get; set; }
        IModelManager ModelManager { get; set; }
        IAssetTypeManager AssetTypeManager { get; set; }
        IManufacturerManager ManufacturerManager { get; set; }

        public AssetController(IAssetManager manager, IModelManager modelManager, IAssetTypeManager assetTypeManager, IManufacturerManager manufacturerManager)
        {
            AssetManager = manager;
            ModelManager = modelManager;
            AssetTypeManager = assetTypeManager;
            ManufacturerManager = manufacturerManager;
        }
        // GET: Asset
        public async Task<IActionResult> GetAll()
        {
            var assets = AssetManager.GetAll();
            var employeeController = new EmployeeController(AssetManager);
            var employees = await employeeController.GetEmployeesAsync();

            var assetList = assets.
                Select(a => new AssetListViewModel //convert to a ViewModel from RentalProperty
                {
                    Description = a.Description,
                    Type = a.AssetType.Name,
                    TagNumber = a.TagNumber,
                    SerialNumber = a.SerialNumber,
                    Employee = employees.Where(e=>e.EmployeeNumber == a.AssignedTo).FirstOrDefault(),
                });          
            
            return View(assetList);
        }

        public IActionResult Index()
        {
            var filters = new AssetSearchViewModel();
            filters.Types = AssetTypeManager.GetAll().Select(o =>
                new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Id.ToString()
                });
            return View(filters);
        }

        [HttpPost]
        public IActionResult GetAssetsByFilters(Filters filter)
        {
            return ViewComponent("FilterAssets", filter);
        }

        public ActionResult GetModelList(int id)
        {
            var list = new List<Model>();
            if (id == 0)
            {
                return Json(list);
            }
            list = ModelManager.GetAll().Where(m => m.ManufacturerId == id).ToList();
            return Json(list);
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            var model = new AssetAddViewModel();
            model.Types = AssetTypeManager.GetAll().Select(t =>
                new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                });
            model.Manufacturers = ManufacturerManager.GetAll().Select(m =>
                new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });
            return View(model);
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

        // GET: Asset/Assign/5
        public ActionResult Assign(int id)
        {
            var asset = AssetManager.Find(id);
            var model = new AssetAssignViewModel()
            {
                TagNumber = asset.TagNumber,
                SerialNumber = asset.SerialNumber,
                Description = asset.Description,
                Manufacturer = asset.Model.Manufacturer.Name,
                Model = asset.Model.Name,
                AssetType = asset.AssetType.Name,
                AssignedTo = asset.AssignedTo
            };
            return View(model);
        }

        // POST: Asset/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(Asset asset)
        {
            try
            {
                // TODO: Add update logic here                
                AssetManager.Assign(asset);
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