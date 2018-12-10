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
            DesktopId,
            LaptopId,
            TabletId,
            MonitorId,
            MobilePhoneId,
            DeskPhoneId
        };

        public int DesktopId { get; set; } = 0;
        public int LaptopId { get; set; } = 0;
        public int TabletId { get; set; } = 0;
        public int MonitorId { get; set; } = 0;
        public int MobilePhoneId { get; set; } = 0;
        public int DeskPhoneId { get; set; } = 0;

        [DisplayName("Employee")]
        public IEnumerable<SelectListItem> Employees { get; set; }
        [DisplayName("Desktop PC")]
        public IEnumerable<SelectListItem> Desktops { get; set; }
        [DisplayName("Laptop")]
        public IEnumerable<SelectListItem> Laptops { get; set; }
        [DisplayName("Tablet")]
        public IEnumerable<SelectListItem> Tablets { get; set; }
        [DisplayName("Monitor")]
        public IEnumerable<SelectListItem> Monitors { get; set; }
        [DisplayName("Mobile Phone")]
        public IEnumerable<SelectListItem> MobilePhones { get; set; }
        [DisplayName("Desk Phone")]
        public IEnumerable<SelectListItem> DeskPhones { get; set; }


    }
    public class Filters
    {
        public int assigned { get; set; }
        public int employee { get; set; }
        public int type { get; set; }
    }
}
