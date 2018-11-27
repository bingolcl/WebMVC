using CPRG102.Properties.App.Models;
using CPRG102.Properties.BLL;
using CPRG102.Properties.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CPRG102.Properties.App.ViewComponents
{
    public class FilterPropertiesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var rentals = RentalsManager.GetAll(); //would be better to define the filter method in the manage class
            //int intID = int.Parse(id);
            IEnumerable<FilteredRentalViewModel> filteredRentals;
            if (id == 0)
            {
                filteredRentals = rentals.Where(r => !r.RenterId.HasValue).
                Select(r => new FilteredRentalViewModel //convert to a ViewModel from RentalProperty
                {
                    Address = r.Address,
                    City = r.City,
                    PostalCode = r.PostalCode,
                    Province = r.Province,
                    Rent = r.Rent.ToString("c"),
                    Style = r.PropertyType.Style
                });
            }
            else
            {
                filteredRentals = rentals.Where(r => r.PropertyTypeId == id && !r.RenterId.HasValue).
                Select(r => new FilteredRentalViewModel //convert to a ViewModel from RentalProperty
                {
                    Address = r.Address,
                    City = r.City,
                    PostalCode = r.PostalCode,
                    Province = r.Province,
                    Rent = r.Rent.ToString("c"),
                    Style = r.PropertyType.Style
                });
            }
            //filter by property type id and where property is not rented
            

            //pass the collection of FilteredRentalViewModels to the view
            return View(filteredRentals);
        }
    }
}
