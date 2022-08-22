using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public ReadEnderecoDto AdicionarEndereco(CreateEnderecoDto dto)
        {
            Endereco endereco = _mapper.Map<Endereco>(dto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RetornarEndereco(string _logradouro)
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            if (enderecos == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(_logradouro))
            {
                IEnumerable<Endereco> query = from endereco in enderecos
                                              where endereco.Logradouro.Any(logradouro => 
                                              endereco.Logradouro == _logradouro)
                                             select endereco;
                enderecos = query.ToList();
            }
            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);

        }

        public ReadEnderecoDto RecuperarEnderecoPorId( int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return enderecoDto;
            }
            return null;
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado!");
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
        public Result DeletarEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado!");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
