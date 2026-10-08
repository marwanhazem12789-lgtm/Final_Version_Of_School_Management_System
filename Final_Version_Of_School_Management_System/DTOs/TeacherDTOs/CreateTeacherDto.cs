using Final_Version_Of_School_Management_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Version_Of_School_Management_System.DTOs.TeacherDTOs
{
    public class CreateTeacherDto
    {
       public string FullName { get; set; }
        [Required, MaxLength(150), EmailAddress]

        public string Email { get; set; }
        [MaxLength(20), Phone]
        public string? PhoneNumber { get; set; }
        [Required, Range(0.1, int.MaxValue)]
        public decimal Price { get; set; }

        public int DepartmentId { get; set; }
    }
}
