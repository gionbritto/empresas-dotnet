using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Validations.Filmes
{
    public class FilmeAptoParaAtualizacaoValidation : AbstractValidator<Filme>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeAptoParaAtualizacaoValidation(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
            throw new NotImplementedException();
        }       
    }
}
