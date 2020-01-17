using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Services.interfaces
{
    public interface IActiveDirectoryService
    {
        bool Authenticate(string userName, string password);
    }
}
