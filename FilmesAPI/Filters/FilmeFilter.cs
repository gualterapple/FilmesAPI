using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Filters
{
    public class FilmeFilter
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
