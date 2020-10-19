using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Interfaces.Services
{
    public interface IFilmeService : IDisposable
    {
        Task<Filme> Adicionar(Filme filme);
        Task<Filme> ObterPorId(Guid id);
        Task<IEnumerable<Filme>> ObterTodos();
        Filme Atualizar(Filme filme);
        bool Inativar(Guid id, Guid idExcluidoPor);
    }
}
