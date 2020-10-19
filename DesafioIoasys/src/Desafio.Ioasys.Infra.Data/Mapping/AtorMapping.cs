using Desafio.Ioasys.Domain.Entities.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Mapping
{
    public class AtorMapping : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder.ToTable("TAtor");
            builder.HasKey(x => x.IdAtor);
            builder.Property(x => x.Nome).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataModificacao).HasColumnType("datetime");
            builder.Property(x => x.DataExclusao).HasColumnType("datetime");
            builder.Property(x => x.IdCriadoPor);
            builder.Property(x => x.IdAtualizadoPor);
            builder.Property(x => x.IdExcluidoPor);

            builder.Ignore(c => c.ValidationResult);
            
        }
    }
}
