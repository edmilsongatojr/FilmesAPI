using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id_Sessao { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioFimSessao { get; set; }
    }
}
