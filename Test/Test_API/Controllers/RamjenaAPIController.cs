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
    [Route("api/RazmjenaAPI")]
    [ApiController]
    public class RazmjenaAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IRazmjenaRepository _dbRazmjena;
        private readonly IStudentRepository _dbStudent;
        private readonly IMapper _mapper;

        public RazmjenaAPIController(IRazmjenaRepository dbRazmjena, IMapper mapper, IStudentRepository dbStudent)
        {
            _dbRazmjena = dbRazmjena;
            _mapper = mapper;
            _dbStudent = dbStudent;
            this._response = new();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRazmjene()
        {
            try
            {
                IEnumerable<Razmjena> razmjenaList = await _dbRazmjena.GetAllAsync();
                _response.Result = _mapper.Map<List<RazmjenaDTO>>(razmjenaList);
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

        [HttpGet("{id:int}", Name = "GetRazmjena")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetRazmjena(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var razmjena = await _dbRazmjena.GetAsync(s => s.Id == id);
                if (razmjena == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<RazmjenaDTO>(razmjena);
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
        public async Task<ActionResult<APIResponse>> CreateRazmjena([FromBody] RazmjenaDTO razmjenaDTO)
        {
            try
            {
                if (await _dbRazmjena.GetAsync(s => s.Id == razmjenaDTO.Id) != null)
                {
                    ModelState.AddModelError("", "Razmjena already Exists!");
                    return BadRequest(ModelState);
                }
                if(await _dbStudent.GetAsync(s => s.Id==razmjenaDTO.StudentId)==null)
                {
                    ModelState.AddModelError("CustomError", "Student ID is Invalid!");
                    return BadRequest(ModelState);
                }
                if (razmjenaDTO == null)
                {
                    return BadRequest(razmjenaDTO);
                }
                if (razmjenaDTO.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Razmjena razmjena = _mapper.Map<Razmjena>(razmjenaDTO);
                await _dbRazmjena.CreateAsync(razmjena);
                _response.Result = _mapper.Map<RazmjenaDTO>(razmjena);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetRazmjena", new { id = razmjena.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteRazmjena")]
        public async Task<ActionResult<APIResponse>> DeleteRazmjena(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var razmjena = await _dbRazmjena.GetAsync(s => s.Id == id);
                if (razmjena == null)
                {
                    return NotFound();
                }
                await _dbRazmjena.RemoveAsync(razmjena);
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

        [HttpPut("{id:int}", Name = "UpdateRazmjena")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateRazmjena(int id, [FromBody] RazmjenaDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }
                if (await _dbStudent.GetAsync(s => s.Id == updateDTO.StudentId) == null)
                {
                    ModelState.AddModelError("CustomError", "Student ID is Invalid!");
                    return BadRequest(ModelState);
                }
                Razmjena model = _mapper.Map<Razmjena>(updateDTO);
                await _dbRazmjena.UpdateAsync(model);
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
    }
}
