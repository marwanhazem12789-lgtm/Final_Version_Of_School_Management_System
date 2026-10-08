using Final_Version_Of_School_Management_System.Models;
using Final_Version_Of_School_Management_System.Unit_Of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Version_Of_School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public DepartmentsController(IUnitOfWork u)
        {
            _unitofwork = u;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var y = _unitofwork.Department.GetAll();
            return Ok(y);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var y = _unitofwork.Department.GetById(id);
            return Ok(y);
        }

        [HttpPost]
        public IActionResult Create(DTOs.DepartmentDTOs.CreateDepartment dto)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var e = new Department
            {
                Name = dto.Name,
                Description = dto.Description,

            };
            _unitofwork.Department.Add(e);
            _unitofwork.Save();
            return Created("", e);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DTOs.DepartmentDTOs.CreateDepartment studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingStudent = _unitofwork.Department.GetById(id);
            if (existingStudent == null)
                return NotFound($"not found.");

            existingStudent.Name = studentDto.Name;
            existingStudent.Description = studentDto.Description;

            _unitofwork.Save();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var tt = _unitofwork.Department.GetById(id);
            if (tt == null) return NotFound(" not found ");

            _unitofwork.Department.Delete(tt);
            _unitofwork.Save();

            return NoContent();
        }


    }
}
