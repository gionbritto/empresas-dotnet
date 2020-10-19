using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.Interfaces.AppService
{
    public interface IUsuarioAppService
    {
        UsuarioViewModel Autenticar(string nomeUsuario, string senha);
    }
}
