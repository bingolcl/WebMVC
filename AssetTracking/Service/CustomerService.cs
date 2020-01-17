using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        IDbContext _context;

        public CustomerService(IDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Customer GetByCustomerNumber(string company, string customerNumber)
        {
            return this.Entities.Where(c => c.Company == company && c.CustomerNumber == customerNumber).FirstOrDefault();
        }
    }
}
