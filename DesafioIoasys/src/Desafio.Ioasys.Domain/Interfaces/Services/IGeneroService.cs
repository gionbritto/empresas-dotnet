using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Interfaces.Services
{
    public interface IGeneroService
    {
        Task<Genero> Adicionar(Genero genero);
        Task<Genero> ObterPorId(Guid id);
        Task<IEnumerable<Genero>> ObterTodos();
    }
}
