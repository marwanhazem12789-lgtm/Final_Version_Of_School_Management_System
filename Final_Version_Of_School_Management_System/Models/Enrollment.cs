using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Version_Of_School_Management_System.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required , Range(0 , 100)]
        public int Grade { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }


        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
