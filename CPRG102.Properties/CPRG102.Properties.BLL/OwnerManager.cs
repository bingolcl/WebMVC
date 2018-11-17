using CPRG102.Properties.Data;
using CPRG102.Properties.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CPRG102.Properties.BLL
{
    public class OwnerManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new RentalsContext();
            var types = context.Owners.Select(o => new
            {
                o.Id,
                o.Name
            }).ToList();
            return types;
        }

        public static List<Owner> GetAll()
        {
            var context = new RentalsContext();
            var owners = context.Owners.ToList();
            return owners;
        }

        public static void Add(Owner owner)
        {
            var context = new RentalsContext();
            context.Owners.Add(owner);
            context.SaveChanges();
        }

        public static Owner Find(int id)
        {
            var context = new RentalsContext();
            var owner = context.Owners.Find(id);
            return owner;
        }

        public static void Update(Owner owner)
        {
            var context = new RentalsContext();
            var o = context.Owners.Find(owner.Id);
            o.Name= owner.Name;
            o.Phone= owner.Phone;
            context.SaveChanges();
        }
    }
}
