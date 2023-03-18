using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using System.Collections.Generic;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployee(int EmployeeId);
        Employee AddEmployee(EmployeeDTO employeeDTO);
        Employee UpdateEmployee(int EmployeeId, EmployeeDTO employeeDTO);
        string RemoveEmployee(int EmployeeId);
    }
}
