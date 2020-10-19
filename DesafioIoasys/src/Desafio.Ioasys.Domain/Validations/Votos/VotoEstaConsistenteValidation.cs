using Desafio.Ioasys.Domain.Entities.Filmes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Validations.Votos
{
    public class VotoEstaConsistenteValidation : AbstractValidator<Voto>
    {
        public VotoEstaConsistenteValidation()
        {
            ValidarIdFilmeVotado();
            ValidarIdUsuario();
            ValidarPontuacao();
        }

        private void ValidarIdFilmeVotado()
        {
            RuleFor(x => x.IdFilme)
                  .NotEmpty()
                  .WithMessage("Para prosseguir com a votação o filme deve ser informado!");
        }

        private void ValidarIdUsuario()
        {
            RuleFor(x => x.IdUsuario)
                  .NotEmpty()
                  .WithMessage("Erro ao validar usuário para votação!");
        }

        private void ValidarPontuacao()
        {
            RuleFor(x => x.Pontuacao)
                  .GreaterThanOrEqualTo(0)
                  .LessThanOrEqualTo(4)
                  .WithMessage("Para votação válida a pontuação deve estar entre 0 e 4");
        }
    }
}
