using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Test_API.Data;
using Test_API.Models;
using Test_API.Models.Dto;
using Test_API.Repository.IRepository;

namespace Test_API.Controllers
{
    [Route("api/StudentAPI")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IStudentRepository _dbStudent;
        private readonly IMapper _mapper;

        public StudentAPIController(IStudentRepository dbStudent, IMapper mapper)
        {
            _dbStudent = dbStudent;
            _mapper = mapper;
            this._response = new();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetStudents()
        {
            try
            {
                IEnumerable<Student> studentList = await _dbStudent.GetAllAsync();
                _response.Result = _mapper.Map<List<StudentDTO>>(studentList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetStudent(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var student = await _dbStudent.GetAsync(s => s.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<StudentDTO>(student);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateStudent([FromBody] StudentDTO studentDTO)
        {
            try
            {
                //if(!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState); 
                //}
                if (await _dbStudent.GetAsync(s => s.Ime.ToLower() == studentDTO.Ime.ToLower()) != null)
                {
                    ModelState.AddModelError("", "Student already Exists!");
                    return BadRequest(ModelState);
                }
                if (studentDTO == null)
                {
                    return BadRequest(studentDTO);
                }
                if (studentDTO.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Student student = _mapper.Map<Student>(studentDTO);

                //Student model = new ()
                //{
                //    Id = studentDTO.Id,
                //    Ime = studentDTO.Ime,
                //    Prezime = studentDTO.Prezime,
                //    JMBAG = studentDTO.JMBAG
                //};
                await _dbStudent.CreateAsync(student);
                _response.Result = _mapper.Map<StudentDTO>(student);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetStudent", new { id = student.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteStudent")]
        public async Task<ActionResult<APIResponse>> DeleteStudent(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var student = await _dbStudent.GetAsync(s => s.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                await _dbStudent.RemoveAsync(student);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateStudent(int id, [FromBody] StudentDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }
                Student model = _mapper.Map<Student>(updateDTO);
                //Student model = new()
                //{
                //    Id = studentDto.Id,
                //    Ime = studentDto.Ime,
                //    Prezime = studentDto.Prezime,
                //    JMBAG = studentDto.JMBAG
                //};
                await _dbStudent.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialStudent(int id, JsonPatchDocument<StudentDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var student = await _dbStudent.GetAsync(s => s.Id == id, tracked: false);

            StudentDTO studentDTO = _mapper.Map<StudentDTO>(student);
            //StudentDTO studentDTO = new()
            //{
            //    Id = student.Id,
            //    Ime = student.Ime,
            //    Prezime=student.Prezime,
            //    JMBAG = student.JMBAG

            //};
            if (student == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(studentDTO, ModelState);
            Student model = _mapper.Map<Student>(studentDTO);

            await _dbStudent.UpdateAsync(model);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
