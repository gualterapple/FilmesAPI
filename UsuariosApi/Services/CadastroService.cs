using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private UserManager<IdentityUser<int>> _userManager;
        private IMapper _mapper;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastrarUsuario(CreateUsuarioDto dto) 
        {
            Usuario user = _mapper.Map<Usuario>(dto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(user);

            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(usuarioIdentity, dto.Password);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");


        }

    }
}
