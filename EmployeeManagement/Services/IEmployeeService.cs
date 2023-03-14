using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployee(int EmployeeId);
        Employee AddEmployee(EmployeeDTO employeeDTO);
        Employee UpdateEmployee(int EmployeeId, EmployeeDTO employeeDTO);
        int RemoveEmployee(int EmployeeId);
    }
}
