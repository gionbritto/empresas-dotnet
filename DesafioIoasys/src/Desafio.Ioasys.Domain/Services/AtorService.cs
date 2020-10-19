using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Services
{
    public class AtorService : IAtorService
    {
        private readonly IAtorRepository _atorRepository;

        public AtorService(IAtorRepository atorRepository)
        {
            _atorRepository = atorRepository;
        }

        public async Task<Ator> Adicionar(Ator ator)
        {
            if (ator == null) return null;

            if (!ator.IsValid())
            {
                return ator;
            }

            ator = await _atorRepository.Adicionar(ator);
            return ator;
        }

        public bool Inativar(Guid id, Guid idExcluidoPor)
        {
            throw new NotImplementedException();
        }

        public async Task<Ator> ObterPorId(Guid id)
        {
            var ator = await _atorRepository.ObterPorId(id);
            return ator;
        }

        public async Task<IEnumerable<Ator>> ObterTodos()
        {
            var atores = await _atorRepository.ObterTodos();
            return atores;
        }
    }
}
