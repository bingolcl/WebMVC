using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG102.Properties.Domain
{
    [Table("RentalProperty")]
    public class RentalProperty
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public decimal Rent { get; set; }
        public int PropertyTypeId { get; set; }
        public int OwnerId { get; set; }
        //nullable int required if FK is nullable
        public int? RenterId { get; set; }

        //navigation properties
        public virtual PropertyType PropertyType { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Renter Renter { get; set; }
    }

}
