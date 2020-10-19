using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Application.Interfaces.Services
{
    public interface IDiretorAppService
    {
        Task<DiretorViewModel> Adicionar(DiretorViewModel diretor);
        Task<DiretorViewModel> ObterPorId(Guid id);
        Task<IEnumerable<DiretorViewModel>> ObterTodos();
    }
}
