using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        private readonly string _ldapServer = @"netbac.network.com";
        private readonly int LdapPort = 3268;
        private readonly string _domainName = @"network";
        private readonly string LdapPathFs = @"LDAP://{0}:{1}/DC={2},DC=com";
        private readonly string UserFilterFs = @"(sAMAccountName={0})";

        public bool Authenticate(string username, string password)
        {
            string ldap = String.Format(LdapPathFs, _ldapServer, LdapPort.ToString(CultureInfo.InvariantCulture), _domainName);
            string userFilter = String.Format(UserFilterFs, username);

            var entry = new DirectoryEntry(ldap, username, password);
            var searcher = new DirectorySearcher(entry) { Filter = userFilter };

            try
            {
                searcher.FindOne();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
