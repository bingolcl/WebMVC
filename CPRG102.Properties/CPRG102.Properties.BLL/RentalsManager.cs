using CPRG102.Properties.Data;
using CPRG102.Properties.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CPRG102.Properties.BLL
{
    public class RentalsManager
    {
        public static List<RentalProperty> GetAll()
        {
            var context = new RentalsContext();
            var rentals = context.RentalProperties.ToList();
            return rentals;
        }

        public static void Add(RentalProperty rental)
        {
            var context = new RentalsContext();
            context.RentalProperties.Add(rental);
            context.SaveChanges();
        }
    }
}
