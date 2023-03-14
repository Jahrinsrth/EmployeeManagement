using EmployeeManagement.Entities;
using System.Collections.Generic;

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
