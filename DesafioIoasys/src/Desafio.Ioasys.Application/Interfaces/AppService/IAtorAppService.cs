using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Application.Interfaces.Services
{
    public interface IAtorAppService
    {
        Task<AtorViewModel> Adicionar(AtorViewModel atorViewModel);
        Task<AtorViewModel> ObterPorId(Guid id);
        Task<IEnumerable<AtorViewModel>> ObterTodos();
    }
}
