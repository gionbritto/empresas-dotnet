using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Application.Interfaces.Services
{
    public interface IGeneroAppService
    {
        Task<GeneroViewModel> Adicionar(GeneroViewModel genero);
        Task<GeneroViewModel> ObterPorId(Guid id);
        Task<IEnumerable<GeneroViewModel>> ObterTodos();
    }
}
