using Desafio.Ioasys.Domain.Entities.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Mapping
{
    public class GeneroMapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {

            builder.ToTable("TGenero");
            builder.HasKey(x => x.IdGenero);
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
