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
            filteredAssets = assets.
                Select(a => new AssetListViewModel //convert to a ViewModel from RentalProperty
                {
                    Description = a.Description,
                    Type = a.AssetType.Name,
                    TagNumber = a.TagNumber,
                    SerialNumber = a.SerialNumber,
                    Employee = employees.Where(e => e.EmployeeNumber == a.AssignedTo).FirstOrDefault(),
                });

            if (filter.assigned == 0)
            {
                filteredAssets = assets.Where(a => String.IsNullOrEmpty(a.AssignedTo)).
                    Select(a => new AssetListViewModel //convert to a ViewModel from RentalProperty
                    {
                        Description = a.Description,
                        Type = a.AssetType.Name,
                        TagNumber = a.TagNumber,
                        SerialNumber = a.SerialNumber,
                        Employee = employees.Where(e => e.EmployeeNumber == a.AssignedTo).FirstOrDefault(),
                    });
            }

            if (filter.assigned == 1)
            {
                filteredAssets = assets.Where(a => !String.IsNullOrEmpty(a.AssignedTo)).
                    Select(a => new AssetListViewModel //convert to a ViewModel from RentalProperty
                    {
                        Description = a.Description,
                        Type = a.AssetType.Name,
                        TagNumber = a.TagNumber,
                        SerialNumber = a.SerialNumber,
                        Employee = employees.Where(e => e.EmployeeNumber == a.AssignedTo).FirstOrDefault(),
                    });
            }

            if (filter.type != -1)
            {
                filteredAssets = assets.Where(a=>a.AssetType.Id == filter.type).
                    Select(a => new AssetListViewModel //convert to a ViewModel from RentalProperty
                    {
                        Description = a.Description,
                        Type = a.AssetType.Name,
                        TagNumber = a.TagNumber,
                        SerialNumber = a.SerialNumber,
                        Employee = employees.Where(e => e.EmployeeNumber == a.AssignedTo).FirstOrDefault(),
                    });
            }

            if (filter.employee != -1)
            {
                filteredAssets = assets.
                    Select(a => new AssetListViewModel
                    {
                        Description = a.Description,
                        Type = a.AssetType.Name,
                        TagNumber = a.TagNumber,
                        SerialNumber = a.SerialNumber,
                        Employee = employees.Where(e => e.EmployeeNumber == a.AssignedTo).FirstOrDefault(),
                    });
                filteredAssets = filteredAssets.Where(l => l.Employee.Id == filter.employee);
                
            }
            return View(filteredAssets);

        }
    }
}
