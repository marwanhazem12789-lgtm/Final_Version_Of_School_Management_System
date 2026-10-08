using System.ComponentModel.DataAnnotations;

namespace Final_Version_Of_School_Management_System.Models
{
    public class ClassRoom
    {
        [Key]
        public int Id { get; set; }
        [Required ,MaxLength(150)] 
        public string Name { get; set; }
        [Required , Range(1 , 12)]
        public int GradeLevel   { get; set; }
        [Required, Range(1, 100)]

        public int Capacity { get; set; }


        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
