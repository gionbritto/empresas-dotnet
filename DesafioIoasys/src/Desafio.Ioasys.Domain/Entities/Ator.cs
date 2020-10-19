using Desafio.Ioasys.Domain.Core;
using Desafio.Ioasys.Domain.Validations.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Entities.Filmes
{
    public class Ator : Entity<Ator>
    {
        public Ator(
           Guid idAtor,
           string nome,
           bool ativo,
           string idCriadoPor,
           string idAtualizadoPor,
           string idExcluidoPor)
        {
            IdAtor = idAtor == Guid.Empty ? Guid.NewGuid() : idAtor;
            Nome = nome;
            Ativo = ativo;
            IdCriadoPor = idCriadoPor;
            IdAtualizadoPor = idAtualizadoPor;
            IdExcluidoPor = idExcluidoPor;
        }

        protected Ator() { }

        public Guid IdAtor { get; protected set; }
        public string Nome { get; protected set; }

        public virtual ICollection<AtorFilme> AtorFilmes { get; protected set; }

        public override bool IsValid()
        {
            return true; //validações não criadas para entidades secundárias/somente leitura
        }
    }
}
