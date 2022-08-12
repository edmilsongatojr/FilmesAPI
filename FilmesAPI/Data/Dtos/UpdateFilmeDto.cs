using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatóio!")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O Genero pode ter no mãximo 30 caracteres!")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração pode ter de 1 a 600 minutos!")]
        public int Duracao { get; set; }
        
    }
}
