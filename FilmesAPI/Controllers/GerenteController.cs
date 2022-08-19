using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService _gerenteService;
        public GerenteController(GerenteService gerenteService)
        {
           _gerenteService = gerenteService;
        }

        [HttpPost]
        public  IActionResult AdicionarGerente(CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionarGerente(dto);
            
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarGerente([FromQuery] string nomeGerente)
        {
            List<ReadGerenteDto> readDto = _gerenteService.RecuperarGerente(nomeGerente);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperarGerentePorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result resultado = _gerenteService.DeletarGerente(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
