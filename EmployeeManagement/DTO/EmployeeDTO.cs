using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DatetOfBirth { get; set; }
        public double? Salary { get; set; }
        public int? DepartmentId { get; set; }
        public string Department { get; set; }

    }
}
