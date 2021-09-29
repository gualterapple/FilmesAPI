﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOs.Cinema
{
    public class ReadGerenteDto
    {
        [Key]
        //[Required]
        public int Id { get; set; }
        //[Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        public object Cinemas { get; set; }

    }
}
