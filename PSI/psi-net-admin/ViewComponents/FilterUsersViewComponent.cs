//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace psi_net_admin.ViewComponents
//{
//    public class FilterUsersViewComponent:ViewComponent
//    {
//        IAssetManager AssetManager { get; set; }

//        public FilterAssetsViewComponent(IAssetManager manager)
//        {
//            AssetManager = manager;
//        }
//        public async Task<IViewComponentResult> InvokeAsync(Filters filter)
//        {
//            var assets = AssetManager.GetAll(); //would be better to define the filter method in the manage class
//            var employeeController = new EmployeeController(AssetManager);
//            var employees = await employeeController.GetEmployeesAsync();
//            //int intID = int.Parse(id);
//            IEnumerable<AssetListViewModel> filteredAssets;
//            filteredAssets = assets.
//                Select(a => new AssetListViewModel
//                {
//                    Description = a.Description,
//                    Type = a.AssetType.Name,
//                    TypeId = a.AssetType.Id,
//                    TagNumber = a.TagNumber,
//                    SerialNumber = a.SerialNumber,
//                    Employee = employees.Where(e => e.EmployeeNumber == a.AssignedTo).FirstOrDefault(),
//                });

//            if (filter.assigned == 0)
//            {
//                filteredAssets = filteredAssets.Where(l => l.Employee == null);
//            }

//            if (filter.assigned == 1)
//            {
//                filteredAssets = filteredAssets.Where(l => l.Employee != null);
//            }

//            if (filter.type != -1)
//            {
//                filteredAssets = filteredAssets.Where(l => l.TypeId == filter.type);
//            }

//            if (filter.employee != -1)
//            {
//                filteredAssets = filteredAssets.Where(l => l.Employee != null && l.Employee.Id == filter.employee);

//            }
//            return View(filteredAssets);

//        }
//    }
//}
