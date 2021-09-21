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
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult adicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes() 
        {
            return Ok(filmes);
        }
        
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id) 
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);   
            if(filme != null)
            {
                return Ok(filme);
            }

            return NotFound();
        }
    }
}
