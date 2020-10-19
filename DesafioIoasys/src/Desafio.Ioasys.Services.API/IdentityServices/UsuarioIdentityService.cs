using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Desafio.Ioasys.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.Ioasys.Services.API.IdentityServices
{
    public class UsuarioIdentityService : IUsuarioIdentityService
    {
        private readonly IConfiguration _configuration;
        public UsuarioIdentityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenAutenticacaoViewModel GerarToken(UsuarioViewModel usuarioViewModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("role", usuarioViewModel.Role),
                    new Claim("nomeUsuario", usuarioViewModel.NomeUsuario),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new TokenAutenticacaoViewModel() { Token = jwtSecurityToken };            
        }
    }
}
