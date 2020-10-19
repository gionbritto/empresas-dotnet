using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Interfaces.Repository
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        bool VerificarFilmeExistente(string nome);
        bool Inativar(Guid id, Guid idExcluidoPor);
    }
}
