using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerLocationService : EntityService<CustomerLocation>, ICustomerLocationService
    {
        IDbContext _context;

        public CustomerLocationService(IDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<CustomerLocation> GetLocationsByCustomer(string company, string customerNumber)
        {
            return this.Entities.Where(l => l.Company == company && l.Customer.CustomerNumber == customerNumber).ToList();
        }
    }
}
