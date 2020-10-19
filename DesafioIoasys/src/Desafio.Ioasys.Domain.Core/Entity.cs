using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Ioasys.Domain.Core
{
    public abstract class Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool IsValid();

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataModificacao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string IdCriadoPor { get; set; }
        public string IdAtualizadoPor { get; set; }
        public string IdExcluidoPor { get; set; }
    }
}
