using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
