using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioApi.Data.Dto;
using UsuarioApi.Models;
namespace UsuarioApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
            CreateMap<Usuario, CustomIdentityUser>();
        }

    }
}
