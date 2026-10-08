using Final_Version_Of_School_Management_System.Models;
using Microsoft.AspNetCore.Server.HttpSys;
using System.ComponentModel.DataAnnotations;

namespace Final_Version_Of_School_Management_System.DTOs.TeacherDTOs
{
    public class GetAllTeachers
    {
        [Key]
        public int Id { get; set; }
       public string FullName { get; set; }
        [Required, MaxLength(150), EmailAddress]

        public string Email { get; set; }
        [MaxLength(20), Phone]
        public string? PhoneNumber { get; set; }
        [Required, Range(0.1, int.MaxValue)]
        public decimal Price { get; set; }

        public string DepartmentName { get; set; }
    }
}
