using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Domain.Interfaces.Services;
using Desafio.Ioasys.Domain.Validations.Votos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Services
{
    public class VotoService : IVotoService
    {
        private readonly IVotoRepository _votoRepository;
        public VotoService(IVotoRepository votoRepository)
        {
            _votoRepository = votoRepository;
        }

        public async Task<Voto> Adicionar(Voto voto)
        {
            if (voto == null) return null;

            if (!voto.IsValid())
            {
                return voto;
            }

            var regrasVoto = new VotoAptoParaCadastroValidation(_votoRepository).Validate(voto);

            foreach (var item in regrasVoto.Errors)
            {
                voto.ValidationResult.Errors.Add(item);
            }

            voto = await _votoRepository.Adicionar(voto);
            return voto;
        }

        public Voto Atualizar(Voto filme)
        {
            throw new NotImplementedException();
        }

        public async Task<Voto> ObterPorId(Guid id)
        {
            var voto = await _votoRepository.ObterPorId(id);
            return voto;
        }

        public async Task<IEnumerable<Voto>> ObterTodos()
        {
            var votos = await _votoRepository.ObterTodos();
            return votos;
        }

        public IEnumerable<Voto> ObterVotosPorIdFilme(Guid id)
        {
            var votos = _votoRepository.ObterVotosPorIdFilme(id);
            return votos;
        }
    }
}
