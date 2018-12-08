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
                return Employee == null ? "" : Employee.Department.Name + ", " + Employee.Department.Location;
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
        [DisplayName("Tag Number")]
        public string TagNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        [DisplayName("Type")]
        public string AssetType { get; set; }
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        
        public string AssignedTo { get; set; }


    }
    public class Filters
    {
        public int assigned { get; set; }
        public int employee { get; set; }
        public int type { get; set; }
    }
}
