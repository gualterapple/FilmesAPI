using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult adicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {

            Models.Cinema cinema = _mapper.Map<Models.Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
                return NotFound();
            else
            {
                if (!string.IsNullOrEmpty(nomeFilme))
                {
                    IEnumerable<Cinema> query = from cinema in cinemas
                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeFilme)
                            select cinema;
                    cinemas = query.ToList();
                }

                List<ReadCinemaDto> dto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
                return Ok(dto);
            }
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            Models.Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                UpdateCinemaDto cinemaDto = _mapper.Map<UpdateCinemaDto>(cinema);
                return Ok(cinemaDto);
            }

            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AlterarCinema(int id, [FromBody] UpdateCinemaDto cinemaNovo)
        {
            Models.Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null)
                return NotFound();

            _mapper.Map(cinemaNovo, cinema);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ApagarCinema(int id)
        {
            Models.Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null)
                return NotFound();

            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
