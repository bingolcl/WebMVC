using CPRG102.Properties.Data;
using CPRG102.Properties.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace CPRG102.Properties.BLL
{
    public class PropertyTypeManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new RentalsContext();
            var types = context.PropertyTypes.Select(pt => new
            {
                pt.Id,
                pt.Style
            }).ToList();
            return types;
        }

        public static List<PropertyType> GetAll()
        {
            var context = new RentalsContext();
            var types = context.PropertyTypes.ToList();
            return types;
        }

        public static PropertyType Find(int id)
        {
            var context = new RentalsContext();
            var type = context.PropertyTypes.Find(id);
            return type;
        }

        public static void Add(PropertyType type)
        {
            var context = new RentalsContext();
            context.PropertyTypes.Add(type);
            context.SaveChanges();
        }
    }

}
