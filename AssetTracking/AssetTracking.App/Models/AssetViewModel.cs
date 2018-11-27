using AssetTracking.BLL;
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

        public string TagNumber { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [DisplayName("Assigned To")]
        public string AssignedTo { get; set; }
    }

    public class AssetSearchViewModel
    {
        public IEnumerable<SelectListItem> Types
        {
            get
            {
                return AssetTypeManager.GetAll().Select(o =>
                new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Id.ToString()
                });
            }
        }


        //public IEnumerable<SelectListItem> Employees
        //{
        //    get
        //    {
        //        return AssetTypeManager.GetAll().Select(o =>
        //        new SelectListItem
        //        {
        //            Text = o.Name,
        //            Value = o.Id.ToString()
        //        });
        //    }

        //}
    }

    public class AssetAddViewModel
    {
        [DisplayName("Tag#"), Required]
        public string TagNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Serial#"), Required]
        public string SerialNumber { get; set; }
        [DisplayName("Type"), Required]
        public string TypeId { get; set; }
        [DisplayName("Manufacturer"), Required]
        public string ManufacturerId { get; set; }
        [DisplayName("Model"), Required]
        public string ModelId { get; set; }
        [DisplayName("Assigned To")]
        public string AssignedTo { get; set; }

        public IEnumerable<SelectListItem> Types
        {
            get
            {
                return AssetTypeManager.GetAll().Select(o =>
                new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Id.ToString()
                });
            }
        }

        public IEnumerable<SelectListItem> Manufacturers
        {
            get
            {
                return ManufacturerManager.GetAll().Select(o =>
                new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Id.ToString()
                });
            }
        }

        public IEnumerable<SelectListItem> Models
        {
            get
            {
                return ModelManger.GetAll().Select(o =>
                new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Id.ToString()
                });
            }
        }
    }
}
