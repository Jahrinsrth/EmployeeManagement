using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Entities
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
