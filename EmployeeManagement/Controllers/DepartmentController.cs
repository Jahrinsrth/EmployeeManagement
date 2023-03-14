using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAllDepartments([FromRoute] int id)
        {
            DepartmentDTO departmentDTO = _departmentService.GetDepartment(id);

            if (departmentDTO == null)
            {
                return NotFound($"No departments found for this departmentId {id}");
            }
            return Ok(departmentDTO);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllDepartments()
        {
            List<DepartmentDTO> departmentDTOs = _departmentService.GetAllDepartment();

            if (departmentDTOs == null && departmentDTOs.Count < 0)
            {
                return NotFound("Department List is empty.. Please add a new department");
            }
            return Ok(departmentDTOs);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult AddDepartmet([FromBody] DepartmentDTO departmentDTO)
        {
            Department department = _departmentService.AddDepartment(departmentDTO);

            if (department == null)
            {
                return BadRequest("department not added");
            }
            return Ok($"Inserted department Id - {department.DepartmentId}");
        }

        [HttpPut]
        [Route("modify/{id}")]
        public IActionResult UpdateDepartment([FromRoute] int id, [FromBody] DepartmentDTO departmentDTO)
        {
            Department department = _departmentService.UpdateDepartment(id, departmentDTO);

            if (department == null)
            {
                return NotFound($"No departmet found for this departmentId {id} to update the record");
            }
            return Ok($"Updated Department - {department.DepartmentId}");
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult DeleteDepartment([FromRoute] int id)
        {
            int departmentId = _departmentService.RemoveDepartment(id);

            if (departmentId < 0)
            {
                return NotFound($"No department found for this departmentId {id} to remove the record");
            }
            return Ok($"Removed department Id {departmentId}");
        }
    }
}
