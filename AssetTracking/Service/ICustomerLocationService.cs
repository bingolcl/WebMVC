using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICustomerLocationService : IEntityService<CustomerLocation>
    {
        List<CustomerLocation> GetLocationsByCustomer(string company, string customerNumber);
    }
}
