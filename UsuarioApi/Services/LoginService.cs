using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuarioApi.Data.Requests;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        //ESSA LINHA abaixo RECUPERA O EMAIL DO USUARIO IDENTITY NO BANCO
        private IdentityUser<int> RecuperaUsuarioPorEmail(string email)
        {
            
            return _signInManager.UserManager.Users
                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users
                    .FirstOrDefault(usuario => usuario.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
                //Acima estamos passando o valor do token nos sucessos do okay para enviar
                //esse token para o LoginController mostrar ao usuario
            }
            return Result.Fail("Login Falhou!");
        }
        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);
            if (identityUser != null)
            {
                string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }
            return Result.Fail("Falha ao Solicitar Redefinição de Senha");
        }
        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);
            IdentityResult identityResult = _signInManager.
                UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;
            if (identityResult.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            return Result.Fail("Houve um erro na redefinição de senha!");
        }
    }
}
