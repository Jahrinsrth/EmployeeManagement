﻿using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee GetEmployee(int employeeId)
        {
            try
            {
                Employee entity = _dbContext.Employees.Include(d => d.Department).FirstOrDefault(e => e.EmployeeId == employeeId);
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = new List<Employee>();

                employees = _dbContext.Employees.Include(d => d.Department).ToList();
                return employees;

                //employees = _dbContext.Employees.FromSqlRaw("spGetAllEmployee").ToList();
                //return employees;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Employee AddEmployee(Employee entity)
        {
            try
            {
                _dbContext.Employees.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Employee UpdateEmployee(Employee entity)
        {
            try
            {
                _dbContext.Employees.Update(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int RemoveEmployee(Employee entity)
        {
            try
            {
                _dbContext.Employees.Remove(entity);
                _dbContext.SaveChanges();
                return entity.EmployeeId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
