using Microsoft.AspNetCore.Identity;
using System;

namespace UsuarioApi.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}
