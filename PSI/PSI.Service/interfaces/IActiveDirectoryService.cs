using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI.Service.interfaces
{
    public interface IActiveDirectoryService
    {
        bool Authenticate(string userName, string password);
    }
}