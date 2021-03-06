﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICustomerService : IEntityService<Customer>
    {
        Customer GetByCustomerNumber(string company, string customerNumber);
    }
}
