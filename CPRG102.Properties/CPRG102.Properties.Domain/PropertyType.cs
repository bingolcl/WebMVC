using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG102.Properties.Domain
{
    [Table("PropertyType")]
    public class PropertyType
    {
        public int Id { get; set; }
        [Required]
        public string Style { get; set; }
        //navigation property
        public ICollection<RentalProperty> RentalProperties { get; set; }
    }

}
