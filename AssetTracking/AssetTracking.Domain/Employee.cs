using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetTracking.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
