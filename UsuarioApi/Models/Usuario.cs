using System;

namespace UsuarioApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
