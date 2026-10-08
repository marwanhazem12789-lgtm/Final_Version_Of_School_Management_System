using System.ComponentModel.DataAnnotations;

namespace Final_Version_Of_School_Management_System.DTOs.AuthDTOs
{
    public class RegisterRequestDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
    }
}
