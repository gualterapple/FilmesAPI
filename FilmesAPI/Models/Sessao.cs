﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public virtual int CinemaId { get; set; }
        public virtual DateTime HorarioDeEncerramento { get; set; }
    }
}