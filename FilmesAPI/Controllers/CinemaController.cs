using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
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
        private CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult adicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto dto = _cinemaService.adicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = dto.Id }, dto);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeFilme)
        {
            List<ReadCinemaDto> dto = _cinemaService.RecuperarCinemas(nomeFilme);
            
            if (dto == null)
                return NotFound();
            else
            {
                return Ok(dto);
            }
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            ReadCinemaDto dto = _cinemaService.RecuperarCinemaPorId(id);
            if (dto != null)
            {
                return Ok(dto);
            }

            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AlterarCinema(int id, [FromBody] UpdateCinemaDto cinemaNovo)
        {
            Result resultado =_cinemaService.AlterarCinema(id, cinemaNovo);
            if (resultado.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ApagarCinema(int id)
        {
            Result resultado = _cinemaService.ApagarCinema(id);

            if (resultado.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
