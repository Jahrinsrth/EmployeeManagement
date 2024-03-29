﻿using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.BuildingBlocks;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            List<Employee> employees = _employeeRepository.GetAllEmployees().ToList();

            _logger.LogInformation("Retrieving data from DB for EmployeeService");

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
                    employeeDTO.Dob = entity.DateOfBirth.ToShortDateString();
                    employeeDTO.Salary = entity.Salary;
                    employeeDTO.DepartmentId = entity.Department.DepartmentId;
                    employeeDTO.Department = entity.Department.DepartmentName;
                    employeeDTO.DatetOfBirth = entity.DateOfBirth;
                    employeeDTO.UserTimeZone = DateTime.UtcNow.ConvertToEST();

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
                employeeDTO.Dob = entity.DateOfBirth.ToShortDateString();
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

            if (entity != null)
            {
                entity.FirstName = employeeDTO.FirstName;
                entity.LastName = employeeDTO.LastName;
                entity.Email = employeeDTO.Email;
                entity.DateOfBirth = (DateTime)employeeDTO.DatetOfBirth;
                entity.Salary = (double)employeeDTO.Salary;
                entity.DepartmentId = (int)employeeDTO.DepartmentId;

                _employeeRepository.UpdateEmployee(entity);
                return entity;
            }
            else 
            {
                return new Employee();
            }

        }
    }
}
