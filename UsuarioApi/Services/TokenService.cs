﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class TokenService
    {
        //CRIAÇÃO DO TOKEN DO USUÁRIO COM ID E USERNAME
        public Token CreateToken(IdentityUser<int> usuario)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("UserName", usuario.UserName),
                new Claim("id", usuario.Id.ToString())
            };
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09sajcnzxn"));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1));
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
