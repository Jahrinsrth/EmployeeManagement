using EmployeeManagement.DTO;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public List<DepartmentDTO> GetAllDepartment()
        {
            List<Department> departments = _departmentRepository.GetAllDepartment().ToList();

            List<DepartmentDTO> departmentDTOs = new List<DepartmentDTO>();

            if (departments != null & departments.Count > 0)
            {
                foreach (Department entity in departments)
                {
                    DepartmentDTO departmentDTO = new DepartmentDTO();

                    departmentDTO.DepartmentId = entity.DepartmentId;
                    departmentDTO.DepartmentName = entity.DepartmentName;
                    departmentDTOs.Add(departmentDTO);
                }
            }

            return departmentDTOs;
        }

        public DepartmentDTO GetDepartment(int departmentId)
        {
            Department entity = _departmentRepository.GetDepartment(departmentId);

            DepartmentDTO departmentDTO = new DepartmentDTO();

            if (entity != null)
            {
                departmentDTO.DepartmentId = entity.DepartmentId;
                departmentDTO.DepartmentName = entity.DepartmentName;
            }

            return departmentDTO;
        }

        public Department AddDepartment(DepartmentDTO departmentDTO)
        {
            Department department = new Department();

            department.DepartmentId = departmentDTO.DepartmentId;
            department.DepartmentName = departmentDTO.DepartmentName;
            department = _departmentRepository.AddDepartment(department);

            return department;
        }

        public Department UpdateDepartment(int departmentId, DepartmentDTO departmentDTO)
        {
            Department entity = _departmentRepository.GetDepartment(departmentId);

            entity.DepartmentName = departmentDTO.DepartmentName;
            _departmentRepository.UpdateDepartment(entity);
            return entity;
        }

        public int RemoveDepartment(int departmentId)
        {
            Department entity = _departmentRepository.GetDepartment(departmentId);
            return _departmentRepository.RemoveDepartment(entity);
        }

    }
}
