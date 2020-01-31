using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_admin.Models
{
    public class UserViewModel
    {
    }
    public class TechViewModel
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string TechnicianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public bool IsActive { get; set; }
        public List<String> Roles { get; set; } = new List<string>();

    }

    public class Filters
    {
        public int assigned { get; set; }
        public int employee { get; set; }
        public int type { get; set; }
    }
}
