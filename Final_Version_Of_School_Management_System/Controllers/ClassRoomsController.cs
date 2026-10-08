using Final_Version_Of_School_Management_System.Models;
using Final_Version_Of_School_Management_System.Unit_Of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Version_Of_School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassRoomsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var classrooms = _unitOfWork.ClassRoom.GetAll();
            return Ok(classrooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classroom = _unitOfWork.ClassRoom.GetById(id);
            if (classroom == null)
            {
                return NotFound($"Classroom with ID {id} not found.");

            }
            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DTOs.ClassRoomDTOs.CreateClassRoomDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classroomEntity = new ClassRoom
            {
                Name = createDto.Name,
                Capacity = createDto.Capacity,
                GradeLevel = createDto.GradeLevel,
                
            };

            _unitOfWork.ClassRoom.Add(classroomEntity);
            _unitOfWork.Save();
            return Created("",classroomEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DTOs.ClassRoomDTOs.CreateClassRoomDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingClassroom = _unitOfWork.ClassRoom.GetById(id);
            if (existingClassroom == null)
            {
                return NotFound($"Classroom with ID {id} not found.");
            }

            existingClassroom.Name = updateDto.Name;
            existingClassroom.Capacity = updateDto.Capacity;
            existingClassroom.GradeLevel = updateDto.GradeLevel;

            _unitOfWork.Save();

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var classroom = _unitOfWork.ClassRoom.GetById(id);
            if (classroom == null)
            {
                return NotFound($"Classroom with ID {id} not found.");
            }

            _unitOfWork.ClassRoom.Delete(classroom);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
