using AssetTracking.App.Controllers;
using AssetTracking.App.Models;
using AssetTracking.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking.App.ViewComponents
{
    public class FilterAssetsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Filters filter)
        {
            var assets = AssetManager.GetAll(); //would be better to define the filter method in the manage class
            var employeeController = new EmployeeController();
            var employees = await employeeController.GetEmployeesAsync();
            //int intID = int.Parse(id);
            IEnumerable<AssetListViewModel> filteredAssets;
            if (filter.assigned == -1 && filter.employee == -1 && filter.type == -1)
            {
                filteredAssets = assets.
                Select(a => new AssetListViewModel //convert to a ViewModel from RentalProperty
                {
                    Description = a.Description,
                    Type = a.AssetType.Name,
                    TagNumber = a.TagNumber,
                    SerialNumber = a.SerialNumber,
                    Employee = employees.Where(e => e.EmployeeNumber == a.AssignedTo).FirstOrDefault(),
                });
                return View(filteredAssets);
            }


            //pass the collection of AssetListViewModels to the view
            return View(new List<AssetListViewModel>());
        }
    }
}
