using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
