using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Interfaces.Services
{
    public interface IDiretorService
    {
        Task<Diretor> Adicionar(Diretor diretor);
        Task<Diretor> ObterPorId(Guid id);
        Task<IEnumerable<Diretor>> ObterTodos();
    }
}
