using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Data.DTOs.Endereco;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("endereco")]
    public class EnderecoContoller : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoContoller(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult adicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {

            Models.Endereco endereco = _mapper.Map<Models.Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Models.Endereco> RecuperarEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            Models.Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(enderecoDto);
            }

            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AlterarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoNovo)
        {
            Models.Endereco endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                return NotFound();

            _mapper.Map(enderecoNovo, endereco);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Apagarendereco(int id)
        {
            Models.Endereco endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                return NotFound();

            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
