using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Validations.Filmes
{
    public class FilmeAptoParaCadastroValidation : AbstractValidator<Filme>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeAptoParaCadastroValidation(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
            FilmeDeveSerUnicoNaBaseSpecification();
        }

        private void FilmeDeveSerUnicoNaBaseSpecification()
        {

            RuleFor(c => c).Must(c => FilmeJaExiste(c.Nome) != true)
                .WithMessage("Filme já cadastrado no sistema.");
        }

        private bool FilmeJaExiste(string nome)
        {
            return _filmeRepository.VerificarFilmeExistente(nome);
        }
    }
}
