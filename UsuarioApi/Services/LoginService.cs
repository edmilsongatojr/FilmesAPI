using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UsuarioApi.Data.Requests;

namespace UsuarioApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login Falhou!");
        }
    }
}
