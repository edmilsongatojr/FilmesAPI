﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo de nome é Obrigatorio!")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }

    }
}
