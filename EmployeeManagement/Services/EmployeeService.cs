using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            List<Employee> employees = _employeeRepository.GetAllEmployees().ToList();

            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();

            if (employees != null & employees.Count > 0)
            {
                foreach (Employee entity in employees)
                {
                    EmployeeDTO employeeDTO = new EmployeeDTO();
                    employeeDTO.EmployeeId = entity.EmployeeId;
                    employeeDTO.FirstName = entity.FirstName;
                    employeeDTO.LastName = entity.LastName;
                    employeeDTO.Email = entity.Email;
                    employeeDTO.DatetOfBirth = entity.DateOfBirth;
                    employeeDTO.Salary = entity.Salary;
                    employeeDTO.DepartmentId = entity.Department.DepartmentId;
                    employeeDTO.Department = entity.Department.DepartmentName;

                    employeeDTOs.Add(employeeDTO);
                }
            }

            return employeeDTOs;
        }

        public EmployeeDTO GetEmployee(int employeeId)
        {
            Employee entity = _employeeRepository.GetEmployee(employeeId);

            EmployeeDTO employeeDTO = new EmployeeDTO();

            if (entity != null)
            {
                employeeDTO.EmployeeId = entity.EmployeeId;
                employeeDTO.FirstName = entity.FirstName;
                employeeDTO.LastName = entity.LastName;
                employeeDTO.Email = entity.Email;
                employeeDTO.DatetOfBirth = entity.DateOfBirth;
                employeeDTO.Salary = entity.Salary;
                employeeDTO.DepartmentId = entity.Department.DepartmentId;
                employeeDTO.Department = entity.Department.DepartmentName;
            }

            return employeeDTO;
        }

        public Employee AddEmployee(EmployeeDTO employeeDTO)
        {
            Employee entity = new Employee();

            entity.EmployeeId = employeeDTO.EmployeeId;
            entity.FirstName = employeeDTO.FirstName;
            entity.LastName = employeeDTO.LastName;
            entity.Email = employeeDTO.Email;
            entity.DateOfBirth = (DateTime)employeeDTO.DatetOfBirth;
            entity.Salary = (double)employeeDTO.Salary;
            entity.DepartmentId = (int)employeeDTO.DepartmentId;

            _employeeRepository.AddEmployee(entity);
            return entity;
        }

        public string RemoveEmployee(int employeeId)
        {
            Employee entity = _employeeRepository.GetEmployee(employeeId);
            if (entity != null)
            {
                return _employeeRepository.RemoveEmployee(entity).ToString();
            }
            else 
            {
                return null;
            }

        }

        public Employee UpdateEmployee(int employeeId, EmployeeDTO employeeDTO)
        {
            Employee entity = _employeeRepository.GetEmployee(employeeId);

            entity.FirstName = employeeDTO.FirstName;
            entity.LastName = employeeDTO.LastName;
            entity.Email = employeeDTO.Email;
            entity.DateOfBirth = (DateTime)employeeDTO.DatetOfBirth;
            entity.Salary = (double)employeeDTO.Salary;
            entity.DepartmentId = (int)employeeDTO.DepartmentId;

            _employeeRepository.UpdateEmployee(entity);
            return entity;
        }
    }
}
