using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Services.API.IdentityServices
{
    public interface IUsuarioIdentityService
    {
        TokenAutenticacaoViewModel GerarToken(UsuarioViewModel usuarioViewModel);
    }
}
