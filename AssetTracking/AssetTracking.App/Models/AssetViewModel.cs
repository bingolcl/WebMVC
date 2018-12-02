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
        [DisplayName("Asset Description")]
        public string Description { get; set; }
        [DisplayName("Asset Type Name")]
        public string Type { get; set; }
        [DisplayName("Asset Tag Number")]
        public string TagNumber { get; set; }
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        [DisplayName("Employee Name")]
        public string Empoyee { get; set; }
        [DisplayName("Department Location")]
        public string Department { get; set; }

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


        public IEnumerable<SelectListItem> Types
        {
            get
            {
                return AssetTypeManager.GetAll().Select(t =>
                new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                });
            }
        }

        public IEnumerable<SelectListItem> Manufacturers
        {
            get
            {
                return ManufacturerManager.GetAll().Select(m =>
                new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });
            }
        }

        //public IEnumerable<SelectListItem> Models
        //{
        //    get
        //    {
        //        return ModelManger.GetAll().Select(o =>
        //        new SelectListItem
        //        {
        //            Text = o.Name,
        //            Value = o.Id.ToString()
        //        });
        //    }
        //}
    }
}
