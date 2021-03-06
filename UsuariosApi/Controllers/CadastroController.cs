
using FluentResults;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CadastroController: ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastroUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastrarUsuario(createDto);
            if(resultado.IsSuccess)
            return Ok();
            return StatusCode(500);
        }

        [HttpGet]
        public IActionResult TestAuthorization()
        {
            return Ok("You're Authorized");
        }
    }
}
