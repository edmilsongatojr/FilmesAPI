using AutoMapper;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioInicioSessao, opts => opts
                .MapFrom(dto =>
                dto.HorarioFimSessao.AddMinutes(dto.Filme.Duracao * (-1))));
            //CreateMap<UpdateCinemaDto, Sessao>();
        }
    }
}
