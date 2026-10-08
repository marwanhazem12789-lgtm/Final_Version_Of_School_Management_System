using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Version_Of_School_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]

        public string LastName { get; set; }
        [Required, MaxLength(150), EmailAddress]

        public string Email { get; set; }
        [MaxLength(20), Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public ClassRoom ClassRoom { get; set; }
        [ForeignKey(nameof(ClassRoom))]
        public int ClassroomId { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    }

}
