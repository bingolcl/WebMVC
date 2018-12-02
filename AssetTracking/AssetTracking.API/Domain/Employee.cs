using System;
using System.Collections.Generic;

namespace AssetTracking.API.Domain
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
