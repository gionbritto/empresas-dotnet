using Desafio.Ioasys.Domain.Entities.Filmes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Validations.Filmes
{
    public class FilmeEstaConsistenteValidation : AbstractValidator<Filme>
    {
        public FilmeEstaConsistenteValidation()
        {
            ValidarNome();
        }
        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do ator é obrigatório.")
                .Length(3, 250).WithMessage("O nome do cliente deve ter entre 3 e 250 caracteres.");
        }
    }
}
