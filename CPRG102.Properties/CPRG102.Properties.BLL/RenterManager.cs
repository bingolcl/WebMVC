using CPRG102.Properties.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG102.Properties.BLL
{
    public class RenterManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new RentalsContext();
            var renters = context.Renters.Select(r => new
            {
                r.Id,
                FullName = $"{r.FirstName} {r.LastName}"
            }).ToList();
            return renters;
        }
    }
}
