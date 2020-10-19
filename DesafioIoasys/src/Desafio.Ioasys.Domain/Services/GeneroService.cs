using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoService)
        {
            _generoRepository = generoService;
        }


        public async Task<Genero> Adicionar(Genero genero)
        {
            if (genero == null) return null;

            if (!genero.IsValid())
            {
                return genero;
            }

            genero = await _generoRepository.Adicionar(genero);
            return genero;
        }


        public async Task<Genero> ObterPorId(Guid id)
        {
            var genero = await _generoRepository.ObterPorId(id);
            return genero;
        }

        public async Task<IEnumerable<Genero>> ObterTodos()
        {
            var generos = await _generoRepository.ObterTodos();
            return generos;
        }
    }
}
