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
        public async Task<IViewComponentResult> InvokeAsync(int assigned, int employee, int type)
        {
            var assets = AssetManager.GetAll(); //would be better to define the filter method in the manage class
            //int intID = int.Parse(id);
            IEnumerable<AssetListViewModel> filteredAssets;
            if (assigned == -1 && employee == -1 && type == -1)
            {
                filteredAssets = assets.
                Select(a => new AssetListViewModel //convert to a ViewModel from RentalProperty
                {
                    TagNumber = a.TagNumber,
                    Description = a.Description,
                    SerialNumber = a.SerialNumber,
                    Type= a.AssetType.Name,

                });
            }


            //pass the collection of AssetListViewModels to the view
            return View(assets);
        }
    }
}
