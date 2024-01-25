
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
    public class AutoriController : Controller
    {
        private readonly Interface.IAutori _autori;
        private readonly IMapper _mapper;
        public AutoriController(Interface.IAutori autori, IMapper mapper)
        {
            _autori = autori;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Autori>))]
        public IActionResult GetAutori()
        {
            var autori = _mapper.Map<List<AutoriDto>>(_autori.GetAutori());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(autori);
        }

        [HttpGet("{CodAutor}")]
        [ProducesResponseType(200, Type = typeof(Autori))]
        [ProducesResponseType(400)]
        public IActionResult GetAutor(int codAutor)
        {
            if (!_autori.AutorExista(codAutor))
                return NotFound();

            var autor = _mapper.Map<AutoriDto>(_autori.GetAutor(codAutor));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(autor);
        }

        [HttpGet("{CodAutor}")]
        [ProducesResponseType(200, Type = typeof(Autori))]
        [ProducesResponseType(400)]
        public IActionResult GetAutorNumePrenume(int codAutor)
        {
            if (!_autori.AutorExista(codAutor))
                return NotFound();

            string nume = _autori.GetAutorNumePrenume(codAutor);

            if (!ModelState.IsValid)
               return BadRequest(ModelState);

           return Ok(nume);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAutor([FromQuery] int codCarte, [FromBody] AutoriDto autorCreate)
        {
            if (autorCreate == null)
                return BadRequest(ModelState);

            var autori = _autori.GetAutori()
                .Where(c => c.CodAutor == autorCreate.CodAutor)
                .FirstOrDefault();

            if (autori != null)
            {
                ModelState.AddModelError("", "Autorul exista deja!");
                return StatusCode(422, ModelState);
            }

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autorMap = _mapper.Map<Autori>(autorCreate);

            if (!_autori.CreateAutor(codCarte, autorMap))
            {
                ModelState.AddModelError("", "A aparut o eroare in timp ce salvam!");
                return StatusCode(500, ModelState);
            }

            return Ok("Avem un angajat nou!");
        }
    }
}
