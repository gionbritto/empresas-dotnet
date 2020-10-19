using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Interfaces.Repository
{
    public interface IVotoRepository : IRepository<Voto>
    {
        IEnumerable<Voto> ObterVotosPorIdFilme(Guid id);
        bool VerificarSeUsuarioExistente(string id);
        bool VerificarSeFilmeExistente(Guid id);
        bool VerificarSeVotoJaExistente(Guid idFilme, string idUsuario);
    }
}
