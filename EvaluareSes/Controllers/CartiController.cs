
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
    public class CartiController : Controller
    {
        private readonly Interface.ICarti _carti;
        private readonly IMapper _mapper;
        public CartiController(Interface.ICarti carti, IMapper mapper)
        {
            _carti = carti;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Carti>))]
        public IActionResult GetCarti()
        {
            var carti = _mapper.Map<List<CartiDto>>(_carti.GetCarti());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carti);
        }

        [HttpGet("{CodCarte}")]
        [ProducesResponseType(200, Type = typeof(Carti))]
        [ProducesResponseType(400)]
        public IActionResult GetCarte(int codCarte)
        {
            if (!_carti.CarteExista(codCarte))
                return NotFound();

            var carte = _mapper.Map<AutoriDto>(_carti.GetCarte(codCarte));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(carte);
        }

        [HttpGet("{CodCarte}")]
        [ProducesResponseType(200, Type = typeof(Carti))]
        [ProducesResponseType(400)]
        public IActionResult GetDenumire(int codCarte)
        {
            if (!_carti.CarteExista(codCarte))
                return NotFound();

            var nume = _carti.GetDenumire(codCarte);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nume);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCarte([FromQuery] int codAutor, [FromBody] CartiDto carteCreate)
        {
            if (carteCreate == null)
                return BadRequest(ModelState);

            var carte = _carti.GetCarti()
                .Where(c => c.CodCarte == carteCreate.CodCarte)
                .FirstOrDefault();

            if (carte != null)
            {
                ModelState.AddModelError("", "Cartea exista deja!");
                return StatusCode(422, ModelState);
            }

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carteMap = _mapper.Map<Carti>(carteCreate);

            if (!_carti.CreateCarte(codAutor, carteMap))
            {
                ModelState.AddModelError("", "A aparut o eroare in timp ce salvam!");
                return StatusCode(500, ModelState);
            }

            return Ok("Avem un angajat nou!");
        }
    }
}
