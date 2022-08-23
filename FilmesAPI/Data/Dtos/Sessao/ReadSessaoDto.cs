using System;

namespace FilmesAPI.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id_Sessao { get; set; }
        public virtual Models.Cinema Cinema { get; set; }
        public virtual Models.Filme Filme { get; set; }
        public DateTime HorarioFimSessao { get; set; }
        public DateTime HorarioInicioSessao { get; set; }
    }
}
