using System.ComponentModel.DataAnnotations;

namespace UsuarioApi.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
