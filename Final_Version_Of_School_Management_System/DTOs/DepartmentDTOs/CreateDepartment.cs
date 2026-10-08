using System.ComponentModel.DataAnnotations;

namespace Final_Version_Of_School_Management_System.DTOs.DepartmentDTOs
{
    public class CreateDepartment
    {
      
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
