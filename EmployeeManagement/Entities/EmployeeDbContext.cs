using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Entities
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department
            {

                DepartmentId = 1,
                DepartmentName = "HR"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                Email = "uncle.bob@gmail.com",
                Salary = 1000.00,
                DateOfBirth = new DateTime(1979, 04, 25),
                DepartmentId = 1
            });
        }
    }
}
