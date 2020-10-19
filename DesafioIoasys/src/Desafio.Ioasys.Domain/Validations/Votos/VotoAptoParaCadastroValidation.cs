using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Validations.Votos
{
    public class VotoAptoParaCadastroValidation : AbstractValidator<Voto>
    {
        private readonly IVotoRepository _votoRepository;

        public VotoAptoParaCadastroValidation(IVotoRepository votoRepository)
        {
            _votoRepository = votoRepository;
            ValidarSeFilmeExistente();
            ValidarSeUsuarioExistente();
            ValidarSeVotoJaExistente();
        }
        private void ValidarSeFilmeExistente()
        {
            RuleFor(x => x).Must(voto =>
                _votoRepository.VerificarSeFilmeExistente(voto.IdFilme) == true)
                .WithMessage("Erro ao validar filme para votação, tente novamente.");
        }

        private void ValidarSeUsuarioExistente()
        {
            RuleFor(x => x).Must(voto =>
                _votoRepository.VerificarSeUsuarioExistente(voto.IdUsuario) == true)
                .WithMessage("Erro ao validar usuario para votação, tente novamente.");
        }

        private void ValidarSeVotoJaExistente()
        {
            RuleFor(x => x).Must(voto =>
                _votoRepository.VerificarSeVotoJaExistente(voto.IdFilme, voto.IdUsuario) == false)        
                .WithMessage("Filme já votado por este usuario, para atualizar a votação....");
        }
    }
}
