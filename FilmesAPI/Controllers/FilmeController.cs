using System.IO;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;
using FilmesAPI.Data;

namespace FilmesAPI
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult adicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id}, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes() 
        {
            return _context.Filmes;
        }
        
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id) 
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);   
            if(filme != null)
            {
                return Ok(filme);
            }

            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AlterarFilme(int id, [FromBody] Filme filmeNovo) 
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
                return NotFound();

            filme.Titulo = filmeNovo.Titulo;
            filme.Genero = filmeNovo.Genero;
            filme.Director = filmeNovo.Director;
            filme.Duracao = filmeNovo.Duracao;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ApagarFilme(int id) 
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
