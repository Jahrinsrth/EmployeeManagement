using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public DepartmentRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Department GetDepartment(int departmentId)
        {
            try
            {
                Department entity = _dbContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            try
            {
                List<Department> departments = new List<Department>();

                departments = _dbContext.Departments.ToList();
                return departments;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Department AddDepartment(Department entity)
        {
            try
            {
                _dbContext.Departments.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Department UpdateDepartment(Department entity)
        {
            try
            {
                _dbContext.Departments.Update(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public int RemoveDepartment(Department entity)
        {
            try
            {
                _dbContext.Departments.Remove(entity);
                _dbContext.SaveChanges();
                return entity.DepartmentId;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
