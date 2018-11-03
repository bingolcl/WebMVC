using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG102.Rentals.Domain
{
    public class PropertyManager
    {
        public static List<RentalProperty> Rentals { get; set; }

        static PropertyManager()
        {
            Rentals = new List<RentalProperty>();
            Rentals.Add(new RentalProperty { id = 1, Address = "1345 - 670 14th Ave SW", City = "Calgary", Province = "AB", PostalCode = "T3T 3T3", Rent = 1200m });
            Rentals.Add(new RentalProperty { id = 2, Address = "4567 66th Ave NW", City = "Calgary", Province = "AB", PostalCode = "T2T 2D2", Rent = 2400m });
            Rentals.Add(new RentalProperty { id = 3, Address = "240 - 2111 4th St NW", City = "Calgary", Province = "AB", PostalCode = "T5T 5T5", Rent = 1800m });
            //Rentals.Add(new RentalProperty { id = 4, Address = "", City = "", Province = "", PostalCode = "", Rent = 29000m });
            //Rentals.Add(new RentalProperty { id = 5, Address = "", City = "", Province = "", PostalCode = "", Rent = 1500m });
            //Rentals.Add(new RentalProperty { id = 6, Address = "", City = "", Province = "", PostalCode = "", Rent = 2000m });
        }

        public static void AddRental(RentalProperty property)
        {
            var lastId = Rentals.Max(r=>r.id);
            property.id = lastId + 1;
            Rentals.Add(property);
        }

        public static RentalProperty GetRental(int id)
        {
            return Rentals.Find(r => r.id == id);
        }

    }
}
