using System.IO;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace FilmesAPI
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public void adicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes() 
        {
            return filmes;
        }
        
        [HttpGet("{id}")]
        public Filme RecuperarFilmePorId(int id) 
        {
            return filmes.FirstOrDefault(filme => filme.Id == id);            
        }
    }
}
