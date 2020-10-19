using Desafio.Ioasys.Domain.Core;
using Desafio.Ioasys.Domain.Validations.Filmes;
using System;
using System.Collections.Generic;

namespace Desafio.Ioasys.Domain.Entities.Filmes
{
    public class Filme : Entity<Filme>
    {
        public Filme(
           Guid idFilme,
           string nome,
           bool ativo,
           string idCriadoPor,
           string idAtualizadoPor,
           string idExcluidoPor)
        {
            IdFilme = idFilme == Guid.Empty ? Guid.NewGuid() : idFilme;
            Nome = nome;
            Ativo = ativo;
            IdCriadoPor = idCriadoPor;
            IdAtualizadoPor = idAtualizadoPor;
            IdExcluidoPor = idExcluidoPor;
        }

        protected Filme() { }

        public Guid IdFilme { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }

        public virtual ICollection<AtorFilme> AtoresFilme { get; protected set; }
        public virtual ICollection<DiretorFilme> DiretoresFilme { get; protected set; }
        public virtual ICollection<GeneroFilme> GenerosFilme { get; protected set; }
        public virtual ICollection<Voto> Votos { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new FilmeEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
