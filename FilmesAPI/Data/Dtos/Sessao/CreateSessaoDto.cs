using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
       
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioFimSessao { get; set; }
    }
}
