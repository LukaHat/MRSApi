using Microsoft.AspNetCore.Mvc;
using Studentska_razmjena_API.Interfaces;
using Studentska_razmjena_API.Models;
using Studentska_razmjena_API.Repository;

namespace Studentska_razmjena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazmjenaController : Controller
    { 
        private readonly IRazmjenaRepository _razmjenaRepository;
        public RazmjenaController(IRazmjenaRepository razmjenaRepository)
        {
            _razmjenaRepository = razmjenaRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Razmjena>))]
        public IActionResult DohvatiRazmjene()
        {
            var razmjene = _razmjenaRepository.DohvatiRazmjene();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(razmjene);
        }
        [HttpGet("{razmjenaId}")]
        [ProducesResponseType(200, Type = typeof(Razmjena))]
        [ProducesResponseType(400)]
        public IActionResult DohvatiStudente(int razmjenaId)
        {
            if (!_razmjenaRepository.RazmjenaPostoji(razmjenaId))
                return NotFound();

            var razmjena = _razmjenaRepository.DohvatiRazmjenu(razmjenaId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(razmjena);
        }
    }
}
