using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage ="O Campo Titulo é Obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Campo Titulo é Obrigatório")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        [Range(1,600,ErrorMessage ="Tamanho invalido: A durãção precisa ter no mninimo 1m e no máximo 600m")]
        public int Duracao { get; set; }
        
    }
}
