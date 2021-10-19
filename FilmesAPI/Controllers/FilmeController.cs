using System.IO;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using AutoMapper;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace FilmesAPI
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [EnableCors("gualterPolicy")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult adicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto dto = _filmeService.adicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = dto.Id}, dto);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null) 
        {
            List<ReadFilmeDto> readDto = _filmeService.RecuperarFilmes();
            if(readDto != null)
            return Ok(readDto);
            return NotFound();

        }
        
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id) 
        {
            ReadFilmeDto dto = _filmeService.RecuperarFilmePorId(id);
            if(dto != null)
            {
                return Ok(dto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AlterarFilme(int id, [FromBody] UpdateFilmeDto filmeNovo) 
        {
            Result resultado = _filmeService.AlterarFilme(id, filmeNovo);
            if (resultado.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ApagarFilme(int id) 
        {
            Result resultado = _filmeService.ApagarFilme(id);           
            if (resultado.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
