using AssetTracking.BLL;
using AssetTracking.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking.App.Models
{
    public class AssetListViewModel
    {
        [DisplayName("Asset Description")]
        public string Description { get; set; }
        [DisplayName("Asset Type Name")]
        public string Type { get; set; }
        [DisplayName("Asset Tag Number")]
        public string TagNumber { get; set; }
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }        
        public Employee Employee { get; set; }
        [DisplayName("Employee Name")]
        public string AssignTo
        {
            get
            {
                return Employee == null ? "" : Employee.FirstName + " " + Employee.LastName;
            }

        }
        [DisplayName("Department Location")]
        public string Department
        {
            get
            {
                return Employee == null ? "" : Employee.Department.Location;
            }
        }

    }

    public class AssetSearchViewModel
    {
        public IEnumerable<SelectListItem> Types { get; set; }
    }

    public class AssetAddViewModel
    {
        [DisplayName("Tag Number"), Required]
        public string TagNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Serial Number"), Required]
        public string SerialNumber { get; set; }
        [DisplayName("Type"), Required]
        public string AssetTypeId { get; set; }
        [DisplayName("Manufacturer"), Required]
        public string ManufacturerId { get; set; }
        [DisplayName("Model"), Required]
        public string ModelId { get; set; }
        [DisplayName("Assigned To")]
        public string AssignedTo { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }

        public IEnumerable<SelectListItem> Manufacturers { get; set; }
    }
    public class AssetAssignViewModel
    {
        [DisplayName("Assigned To"), Required]
        public string EmployeeNumber { get; set; }

        public List<int> AssetIds => new List<int>
        {
            DesktopId?? 0,
            LaptopId?? 0,
            TabletId?? 0,
            MonitorId?? 0,
            MobilePhoneId?? 0,
            DeskPhoneId?? 0
        };
        [DisplayName("Desktop PC")]
        public int? DesktopId { get; set; }
        [DisplayName("Laptop")]
        public int? LaptopId { get; set; }
        [DisplayName("Tablet")]
        public int? TabletId { get; set; }
        [DisplayName("Monitor")]
        public int? MonitorId { get; set; }
        [DisplayName("Mobile Phone")]
        public int? MobilePhoneId { get; set; }
        [DisplayName("Desk Phone")]
        public int? DeskPhoneId { get; set; }
        
        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> Desktops { get; set; }
        public IEnumerable<SelectListItem> Laptops { get; set; }
        public IEnumerable<SelectListItem> Tablets { get; set; }
        public IEnumerable<SelectListItem> Monitors { get; set; }
        public IEnumerable<SelectListItem> MobilePhones { get; set; }
        public IEnumerable<SelectListItem> DeskPhones { get; set; }


    }
    public class Filters
    {
        public int assigned { get; set; }
        public int employee { get; set; }
        public int type { get; set; }
    }
}
