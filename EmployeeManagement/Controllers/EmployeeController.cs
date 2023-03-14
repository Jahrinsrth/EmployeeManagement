using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployee([FromRoute] int id)
        {
            EmployeeDTO employeeDTO = _employeeService.GetEmployee(id);

            if (employeeDTO == null)
            {
                return NotFound($"No employees found for this employeeId {id}");
            }
            return Ok(employeeDTO);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllEmployees()
        {
            List<EmployeeDTO> employeeDTOs = _employeeService.GetAllEmployees();

            if (employeeDTOs == null && employeeDTOs.Count > 0)
            {
                return NotFound("Employee List is empty.. Please add a new employee");
            }
            return Ok(employeeDTOs);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            Employee employee = _employeeService.AddEmployee(employeeDTO);

            if (employee == null)
            {
                return BadRequest("employee not added");
            }
            return Ok($"Inserted employee Id - {employee.EmployeeId}");
        }


        [HttpPut]
        [Route("modify/{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] EmployeeDTO employeeDTO)
        {
            Employee employee = _employeeService.UpdateEmployee(id, employeeDTO);

            if (employee == null)
            {
                return NotFound($"No employees found for this employeeId {id} to update the record");
            }
            return Ok($"Updated employee - {employee.EmployeeId}");
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            int employeeId = _employeeService.RemoveEmployee(id);

            if (employeeId < 0)
            {
                return NotFound($"No employees found for this employeeId {id} to remove the record");
            }
            return Ok($"Removed Employee Id {employeeId}");
        }
    }
}
