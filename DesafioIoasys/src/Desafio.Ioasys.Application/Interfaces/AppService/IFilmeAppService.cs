using Desafio.Ioasys.Application.ViewModels.Filmes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Application.Interfaces.Services
{
    public interface IFilmeAppService : IDisposable
    {
        Task<FilmeViewModel> Adicionar(FilmeViewModel filme);
        Task<FilmeViewModel> ObterPorId(Guid id);
        Task<IEnumerable<FilmeViewModel>> ObterTodos();
        Task<FilmeViewModel> Atualizar(FilmeViewModel filme);
        bool Inativar(Guid id, Guid idExcluidoPor);
    }
}
