using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG102.Properties.BLL;
using CPRG102.Properties.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CPRG102.Properties.App.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {
            var owners = OwnerManager.GetAll();
            return View(owners);
        }

        public IActionResult Create()
        {
            var owner = new Owner();
            return View(owner);
        }

        [HttpPost]
        public IActionResult Create(Owner owner)
        {
            OwnerManager.Add(owner);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var owner = OwnerManager.Find(id);
            return View(owner);
        }

        [HttpPost]
        public IActionResult Edit(Owner owner)
        {
            OwnerManager.Update(owner);
            return RedirectToAction(nameof(Index));
        }

    }
}