using Microsoft.AspNetCore.Mvc;
using Studentska_razmjena_API.Data;
using Studentska_razmjena_API.Interfaces;
using Studentska_razmjena_API.Models;

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
            if(!ModelState.IsValid) 
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
    }
}
