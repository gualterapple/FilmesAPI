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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System.Linq.Dynamic.Core;

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

        [HttpPost("filmeECapa")]
        public IActionResult adicionaFilme([FromForm] CreateFilmeDto filmeDto, [FromForm] IFormFile capa)
        {
            filmeDto.Capa = WriteFileAndGetName(capa);
            ReadFilmeDto dto = _filmeService.adicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = dto.Id}, dto);
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
        
        [HttpGet("buscarFilmes")]
        public IActionResult RecuperarFilmePorFiltro(
            [FromQuery] FilmeFilter filter,
            [FromQuery] FilmeOrdem ordem,
            [FromQuery] FilmesPaginacao paginacao) 
        {
            IQueryable<ReadFilmeDto> readDto = 
                _filmeService.RecuperarFilmesFilter(filter)
                .AplicaFiltro(filter)
                .AplicarOrdem(ordem);
            if (readDto != null)
            return Ok(readDto.ToFilmePaginado(paginacao));
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

        private async Task<string> WriteFile(IFormFile file) 
        {
            string fileName = "";

            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\capas");
                if (!Directory.Exists(pathBuilt)) 
                {
                    Directory.CreateDirectory(pathBuilt);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\capas", fileName);

                using(var stream = new FileStream(path, FileMode.Create)) 
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return fileName;
        }   
        
        private string WriteFileAndGetName(IFormFile file) 
        {
            string fileName = "";

            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\capas");
                if (!Directory.Exists(pathBuilt)) 
                {
                    Directory.CreateDirectory(pathBuilt);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\capas", fileName);

                using(var stream = new FileStream(path, FileMode.Create)) 
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return fileName;
        }

        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(string fileName) 
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\capas", fileName);
            var provider = new FileExtensionContentTypeProvider();

            if(!provider.TryGetContentType(filePath, out var contentType)) 
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            //Retornado a imagem
            //return File(bytes, contentType, Path.GetFileName(filePath));
            return Ok(bytes);
        }
        
        public byte[] GetBytes(string fileName) 
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\capas", fileName);
            var provider = new FileExtensionContentTypeProvider();

            if(!provider.TryGetContentType(filePath, out var contentType)) 
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);
            //Retornado a imagem
            //return File(bytes, contentType, Path.GetFileName(filePath));
            return bytes;
        }

        [HttpPost]
        [Route("SavarCapa")]
        public async Task<ActionResult> UploadFile(IFormFile file) 
        {
            var result = await WriteFile(file);
            return Ok(result);
        }
    }
}
