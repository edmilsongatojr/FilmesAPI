using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionarSessao(dto);
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = readDto.Id_Sessao }, readDto);
        }

        //[HttpGet]
        //public IEnumerable<Sessao> RetornarSessao()
        //{
        //    return _context.Sessoes;
        //}

        // [HttpGet("{id}")]
        [HttpGet]
        public IActionResult RecuperarSessaoPorId(int id)
        {
           ReadSessaoDto readDto = _sessaoService.RecuperSessaoPorId(id);
           if (readDto != null) return Ok(readDto);
           return NotFound();
        }
    }
}
