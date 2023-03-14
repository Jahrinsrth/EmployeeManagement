using EmployeeManagement.Entities;
using System.Collections.Generic;

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
