using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionarSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao); 
        }

        public List<ReadSessaoDto> RecuperSessaoPorId(int? id)
        {
            //Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id_Sessao == id);
            //if (sessao != null)
            //{
            //    ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            //    return Ok(sessaoDto);
            //}

            List<Sessao> sessoes;
            if (id == null)
            {
                sessoes = _context.Sessoes.ToList();
            }
            else
            {
                sessoes = _context.Sessoes.Where(sessao => sessao.Id_Sessao <= id)
               .ToList();
            }
            if (sessoes != null)
            {
                List<ReadSessaoDto> readDto = _mapper.Map<List<ReadSessaoDto>>(sessoes);
                return readDto;
            }
            return null;
        }
    }
}
