using System.ComponentModel.DataAnnotations;

namespace Final_Version_Of_School_Management_System.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }    
    }
}
