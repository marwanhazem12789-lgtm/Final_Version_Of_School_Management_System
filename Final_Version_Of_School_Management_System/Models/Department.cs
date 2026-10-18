using System.ComponentModel.DataAnnotations;

namespace Final_Version_Of_School_Management_System.Models
{
    public class Department
    {
        //FirstComment
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }


        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
