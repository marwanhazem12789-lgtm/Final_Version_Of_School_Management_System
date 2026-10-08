using AutoMapper;
using Final_Version_Of_School_Management_System.DTOs.TeacherDTOs;
using Final_Version_Of_School_Management_System.Models;
using Final_Version_Of_School_Management_System.Unit_Of_Work;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Final_Version_Of_School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper ;

        public TeachersController(IUnitOfWork unitOfWork , IMapper mo)
        {
            _unitOfWork = unitOfWork;
            mapper = mo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _unitOfWork.Teacher.GetAll();
var t = mapper.Map<List<GetAllTeachers>>(teachers);

            return Ok(t);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _unitOfWork.Teacher.GetById(id);
            var t = mapper.Map<GetAllTeachers>(teacher);
            return Ok(t);
        }
        [HttpPost]
        public IActionResult Create([FromBody] DTOs.TeacherDTOs.CreateTeacherDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var e = mapper.Map<Teacher>(createDto);
            _unitOfWork.Teacher.Add(e);
            _unitOfWork.Save();

            return Created("",e);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DTOs.TeacherDTOs.CreateTeacherDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTeacher = _unitOfWork.Teacher.GetById(id);
            if (existingTeacher == null)
            {
                return NotFound($"Teacher with ID {id} not found.");
            }

            var department = _unitOfWork.Teacher.GetById(updateDto.DepartmentId);
            if (department == null)
            {
                return BadRequest($"Department with ID {updateDto.DepartmentId} does not exist.");
            }

            var e = mapper.Map<Teacher>(updateDto);
            _unitOfWork.Teacher.Update(e);
            _unitOfWork.Save();

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _unitOfWork.Teacher.GetById(id);
            if (teacher == null)
            {
                return NotFound($"Teacher with ID {id} not found.");
            }

            _unitOfWork.Teacher.Delete(teacher);
            _unitOfWork.Save();

            return NoContent(); 
        }
    }
}