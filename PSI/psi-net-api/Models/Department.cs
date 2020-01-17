using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
