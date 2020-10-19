using Desafio.Ioasys.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Entities.Filmes
{
    public class Diretor : Entity<Diretor>
    {
        public Diretor(
            Guid idDiretor,
            string nome,
            bool ativo,
            string idCriadoPor,
            string idAtualizadoPor,
            string idExcluidoPor)
        {
            IdDiretor = idDiretor == Guid.Empty ? Guid.NewGuid() : idDiretor;
            Nome = nome;
            Ativo = ativo;
            IdCriadoPor = idCriadoPor;
            IdAtualizadoPor = idAtualizadoPor;
            IdExcluidoPor = idExcluidoPor;
            
        }

        protected Diretor() { }

        public Guid IdDiretor { get; protected set; }
        public string Nome { get; protected set; }

        public virtual ICollection<DiretorFilme> DiretorFilmes { get; protected set; }

        public override bool IsValid()
        {
            return true; //validações não criadas para entidades secundárias/somente leitura
        }
    }
}
