using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Version_Of_School_Management_System.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]

        public string LastName { get; set; }
        [Required, MaxLength(150) ,EmailAddress]

        public string Email { get; set; }
        [MaxLength(20) , Phone]
        public string? PhoneNumber { get; set; }
        [Required , Range(0.1 , int.MaxValue)]
        public decimal Price { get; set; }

        public Department Department { get; set; }
        [ForeignKey(nameof(Department))]
        public int  DepartmentId { get; set; }


        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
