using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Endereco
{
    public class CreateEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
