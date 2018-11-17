using CPRG102.Properties.BLL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Properties.App.Models
{
    public class RentalViewModel
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Rent { get; set; }
        [Required]
        [DisplayName("Style")]
        public string PropertyTypeId { get; set; }
        [DisplayName("Owner"), Required]
        public string OwnerId { get; set; }

        public IEnumerable<SelectListItem> Owners {
            get
            {
                return OwnerManager.GetAll().Select(o =>
                new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Id.ToString()
                });
            }

        }
        public IEnumerable<SelectListItem> PropertyTypes {
            get
            {
                var types = PropertyTypeManager.GetAll().Select(t =>
                new SelectListItem
                {
                    Text = t.Style,
                    Value = t.Id.ToString()
                });
                //types.ToList()[0].Selected = true;
                return types;
            }
        }
    }
}
