using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _endereco;
        public EnderecoController(EnderecoService endereco)
        {
            _endereco = endereco;
        }
        [HttpPost]
        public IActionResult AdicionarEndereco(CreateEnderecoDto dto)
        {
            ReadEnderecoDto readDto = _endereco.AdicionarEndereco(dto);
            return CreatedAtAction(nameof(RecuperarEnderecosPorId), new { Id = readDto.Id }, readDto);
        
        }

        [HttpGet]
        public IActionResult RetornarEnderecos([FromQuery] string logradouro)
        {
            List<ReadEnderecoDto> readDto = _endereco.RetornarEndereco(logradouro);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        
        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecosPorId(int id)
        {
            ReadEnderecoDto readDto = _endereco.RecuperarEnderecoPorId(id);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result resultado = _endereco.AtualizarEndereco(id,enderecoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Result resultado = _endereco.DeletarEndereco(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
