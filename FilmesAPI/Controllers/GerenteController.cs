using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Data.DTOs.Gerente;
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
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto novoGerente) 
        {
            Gerente gerente = _mapper.Map<Gerente>(novoGerente);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id) 
        {
            Gerente g = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            if (g != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(g);
                return Ok(gerenteDto);
            }

            return NotFound();
        }
    }

    

}
