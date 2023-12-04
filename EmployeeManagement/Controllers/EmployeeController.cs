using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployee([FromRoute] int id)
        {
            if (id > 0)
            {
                EmployeeDTO employeeDTO = _employeeService.GetEmployee(id);
                if (employeeDTO == null)
                {
                    return NotFound($"No employees found for this employeeId {id}");
                }
                return Ok(employeeDTO);
            }
            else 
            {
                return BadRequest($"Invalid employeeId - {id}");
            } 
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllEmployees()
        {
            List<EmployeeDTO> employeeDTOs = _employeeService.GetAllEmployees();

            if (employeeDTOs == null && employeeDTOs.Count < 0)
            {
                return NotFound("Employee List is empty... Please add a new employee");
            }
            return Ok(employeeDTOs);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (employeeDTO != null)
            {
                Employee employee = _employeeService.AddEmployee(employeeDTO);

                if (employee == null)
                {
                    return BadRequest("employee not added");
                }
                return Ok($"Inserted employee Id - {employee.EmployeeId}");
            }
            else 
            {
                return BadRequest($"Invalid Payload - {employeeDTO.ToString()}");
            }
        }

        [HttpPut]
        [Route("modify/{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (id > 0)
            {
                Employee employee = _employeeService.UpdateEmployee(id, employeeDTO);

                if (employee.EmployeeId == 0)
                {
                    return NotFound($"No employees found for this employeeId {id} to update the record");
                }

                return Ok($"Updated employee - {employee.EmployeeId}");
            }
            else 
            {
                return BadRequest($"Invalid employeeId - {id}");
            }          
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            if (id > 0) 
            {
                string employeeId = _employeeService.RemoveEmployee(id);

                if (employeeId == null)
                {
                    return NotFound($"No employees found for this employeeId {id} to remove the record");
                }
                return Ok($"Removed employeeId - {id}");
            }
            else    
            {
                return BadRequest($"Invalid employeeId - {id}");
            }
        }

        #region application launching 
        [HttpGet]
        [Route("application")]
        public IActionResult ApplicationLaunchURL()
        {
            _logger.LogInformation("Application started");
            var employess = _employeeService.GetAllEmployees();

            if (employess != null && employess.Count > 0)
            {
                _logger.LogInformation("data  fetched for Employee controller");
                return Ok("Success - Application up and running");
            }
            else 
            {
                _logger.LogError("Application failed to start");
                return Ok("Warning - Application connection failed");
            }
        }
        #endregion
    }
}
