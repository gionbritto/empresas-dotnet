using Desafio.Ioasys.Application.Interfaces.AppService;
using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Ioasys.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private List<UsuarioViewModel> _users = new List<UsuarioViewModel>
        {
            new UsuarioViewModel { NomeCompleto = "Simone Alvin", NomeUsuario = "salvin", Senha = "test@123", Role = "Admin" },
            new UsuarioViewModel {  NomeCompleto = "Sabrina", NomeUsuario = "sabs", Senha = "pass@123", Role = "Padrao" }
        };

        public UsuarioViewModel Autenticar(string nomeUsuario, string senha)
        {
            var usuario = _users.SingleOrDefault(x => x.NomeUsuario == nomeUsuario && x.Senha == senha);

            if (usuario == null)
            {
                return null;
            }
            else
            {
                usuario.SucessoLogin = true;
            }

            return usuario;
        }
    }
}
