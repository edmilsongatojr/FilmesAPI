using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionarGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> RecuperarGerente(string nomeGerente)
        {

            List<Gerente> gerentes = _context.Gerentes.ToList();
            if (gerentes == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeGerente))
            {
                IEnumerable<Gerente> query = from gerente in gerentes
                                             where gerente.Nome.Any(nome =>
                                            gerente.Nome == nomeGerente)
                                            select gerente;
                gerentes = query.ToList();
            }
            return _mapper.Map<List<ReadGerenteDto>>(gerentes);

        }

        public ReadGerenteDto RecuperarGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return gerenteDto;
            }
            return null;
        }

        public Result DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Filme não Encontrado!");
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
