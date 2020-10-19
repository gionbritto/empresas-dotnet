using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Interfaces.Services
{
    public interface IAtorService
    {
        Task<Ator> Adicionar(Ator ator);
        Task<Ator> ObterPorId(Guid id);
        Task<IEnumerable<Ator>> ObterTodos();
    }
}
