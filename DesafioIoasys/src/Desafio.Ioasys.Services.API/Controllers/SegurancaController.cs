using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Ioasys.Application.Interfaces.AppService;
using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain;
using Desafio.Ioasys.Services.API.IdentityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.Ioasys.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IUsuarioIdentityService _usuarioIdentityService;

        public SegurancaController(IConfiguration configuration,
                                   IUsuarioAppService usuarioAppService,
                                   IUsuarioIdentityService usuarioIdentityService)
        {
            _configuration = configuration;
            _usuarioAppService = usuarioAppService;
            _usuarioIdentityService = usuarioIdentityService;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UsuarioViewModel usuarioLogin)
        {
            var resultado = _usuarioAppService.Autenticar(usuarioLogin.NomeUsuario, usuarioLogin.Senha);
            if (resultado != null && resultado.SucessoLogin)
            {
                var tokenJwt = _usuarioIdentityService.GerarToken(resultado);
                return Ok(new { token = tokenJwt.Token });
            }
            else
            {
                return Unauthorized();
            }
        } 

        
    }
}