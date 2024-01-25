
using AutoMapper;
using EvaluareSes.Dto;
using EvaluareSes.Interface;
using EvaluareSes.Models;
using EvaluareSes.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluareSes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdituraController : Controller
    {
        private readonly Interface.IEditura _editura;
        private readonly IMapper _mapper;
        public EdituraController(Interface.IEditura editura, IMapper mapper)
        {
            _editura = editura;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Editura>))]
        public IActionResult GetEdituri()
        {
            var edituri = _mapper.Map<List<CartiDto>>(_editura.GetEdituri());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(edituri);
        }

        [HttpGet("{CodEditura}")]
        [ProducesResponseType(200, Type = typeof(Editura))]
        [ProducesResponseType(400)]
        public IActionResult GetEditura(int codEditura)
        {
            if (!_editura.EdituraExista(codEditura))
                return NotFound();

            var carte = _mapper.Map<AutoriDto>(_editura.GetEditura(codEditura));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(carte);
        }

        [HttpGet("{CodEditura}")]
        [ProducesResponseType(200, Type = typeof(Editura))]
        [ProducesResponseType(400)]
        public IActionResult GetDenumire(int codEditura)
        {
            if (!_editura.EdituraExista(codEditura))
                return NotFound();

            var nume = _editura.GetDenumire(codEditura);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nume);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEditura( [FromBody] EdituraDto edituraCreate)
        {
            if (edituraCreate == null)
                return BadRequest(ModelState);

            var editura = _editura.GetEdituri()
                .Where(c => c.CodEditura == edituraCreate.CodEditura)
                .FirstOrDefault();

            if (editura != null)
            {
                ModelState.AddModelError("", "Editura exista deja!");
                return StatusCode(422, ModelState);
            }

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var edituraMap = _mapper.Map<Editura>(edituraCreate);

            if (!_editura.CreateEditura(edituraMap))
            {
                ModelState.AddModelError("", "A aparut o eroare in timp ce salvam!");
                return StatusCode(500, ModelState);
            }

            return Ok("Avem un angajat nou!");
        }
    }
}
