using System;

namespace CPRG102.Rentals.Domain
{
    public class RentalProperty
    {
        public int id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public decimal Rent { get; set; }        
    }
}
