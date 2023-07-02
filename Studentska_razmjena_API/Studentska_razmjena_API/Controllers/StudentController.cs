using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Studentska_razmjena_API.Data;
using Studentska_razmjena_API.Dto;
using Studentska_razmjena_API.Interfaces;
using Studentska_razmjena_API.Models;
using System.Diagnostics.Metrics;

namespace Studentska_razmjena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository, DataContext context)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult DohvatiStudente()
        {
            var studenti = _studentRepository.DohvatiStudente();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(studenti);
        }

        [HttpGet("{StudentId}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult DohvatiStudente(int StudentId)
        {
            if (!_studentRepository.StudentPostoji(StudentId))
                return NotFound();

            var student = _studentRepository.DohvatiStudente(StudentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult StvoriStudenta([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var uspjeh = _studentRepository.StvoriStudenta(student);

            if (uspjeh)
            {
                return CreatedAtAction(nameof(DohvatiStudente), new { StudentId = student.Id }, student);
            }
            else
            {
                return BadRequest("Failed to create student.");
            }
        }
    }
}
