using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Interfaces.Services
{
    public interface IVotoService
    {
        Task<Voto> Adicionar(Voto voto);
        Task<Voto> ObterPorId(Guid id);
        Task<IEnumerable<Voto>> ObterTodos();
        IEnumerable<Voto> ObterVotosPorIdFilme(Guid id);
        Voto Atualizar(Voto voto);
    }
}
