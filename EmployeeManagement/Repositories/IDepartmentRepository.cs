using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartment();
        Department GetDepartment(int departmentId);
        Department AddDepartment(Department department);
        Department UpdateDepartment(Department department);
        int RemoveDepartment(Department department);

    }
}
