using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O Campo de nome é Obrigatorio!")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
    }
}
