using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Services
{
    public class DiretorService : IDiretorService
    {
        private readonly IDiretorRepository _diretorRepository;

        public DiretorService(IDiretorRepository diretorRepository)
        {
            _diretorRepository = diretorRepository;
        }

        public async Task<Diretor> Adicionar(Diretor diretor)
        {
            if (diretor == null) return null;

            if (!diretor.IsValid())
            {
                return diretor;
            }

            diretor = await _diretorRepository.Adicionar(diretor);
            return diretor;
        }

        public async Task<Diretor> ObterPorId(Guid id)
        {
            var diretor = await _diretorRepository.ObterPorId(id);
            return diretor;
        }

        public async Task<IEnumerable<Diretor>> ObterTodos()
        {
            var diretores = await _diretorRepository.ObterTodos();
            return diretores;
        }
      
    }
}
