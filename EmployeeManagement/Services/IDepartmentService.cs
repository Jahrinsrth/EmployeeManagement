using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using System.Collections.Generic;

namespace EmployeeManagement.Services
{
    public interface IDepartmentService
    {
        List<DepartmentDTO> GetAllDepartment();
        DepartmentDTO GetDepartment(int departmentId);
        Department AddDepartment(DepartmentDTO departmentDTO);
        Department UpdateDepartment(int departmentId, DepartmentDTO departmentDTO);
        int RemoveDepartment(int departmentId);
    }
}
