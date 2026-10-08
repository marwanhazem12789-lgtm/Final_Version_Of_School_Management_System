using System.ComponentModel.DataAnnotations;

namespace Final_Version_Of_School_Management_System.DTOs.ClassRoomDTOs
{
    public class CreateClassRoomDto
    {
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required, Range(1, 12)]
        public int GradeLevel { get; set; }
        [Required, Range(1, 100)]

        public int Capacity { get; set; }
    }
}
