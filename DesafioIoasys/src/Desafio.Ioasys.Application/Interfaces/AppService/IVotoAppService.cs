using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Application.Interfaces.AppService
{
    public interface IVotoAppService
    {
        Task<VotoViewModel> Adicionar(VotoViewModel voto);
        Task<VotoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<VotoViewModel>> ObterTodos();
        IEnumerable<VotoViewModel> ObterVotosPorIdFilme(Guid id);
        Task<VotoViewModel> Atualizar(VotoViewModel voto);
    }
}
