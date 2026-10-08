using System.ComponentModel.DataAnnotations;

namespace Final_Version_Of_School_Management_System.DTOs.AuthDTOs
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
