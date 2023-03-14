using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int EmployeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        int RemoveEmployee(Employee employee);
        Department AddDepartment(Department department);
    }
}
