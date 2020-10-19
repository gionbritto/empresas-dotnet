using Desafio.Ioasys.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Entities.Filmes
{
    public class Genero : Entity<Genero>
    {
        public Genero(
           Guid idGenero,
           string nome,
           bool ativo,
           string idCriadoPor,
           string idAtualizadoPor,
           string idExcluidoPor)
        {
            IdGenero = idGenero == Guid.Empty ? Guid.NewGuid() : idGenero;
            Nome = nome;
            Ativo = ativo;
            IdCriadoPor = idCriadoPor;
            IdAtualizadoPor = idAtualizadoPor;
            IdExcluidoPor = idExcluidoPor;
        }

        protected Genero() { }

        public Guid IdGenero { get; protected set; }
        public string Nome { get; protected set; }

        public virtual ICollection<GeneroFilme> GeneroFilmes { get; protected set; }

        public override bool IsValid()
        {
            return true; //validações não criadas para entidades secundárias/somente leitura
        }
    }
}
