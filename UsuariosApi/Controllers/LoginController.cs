using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogarUsuario(request);
            if (resultado.IsSuccess)
                return Ok(resultado.Successes);
            return Unauthorized(resultado.Errors);
        }

    }
}
