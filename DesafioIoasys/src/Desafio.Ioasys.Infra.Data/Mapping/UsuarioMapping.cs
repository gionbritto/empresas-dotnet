using Desafio.Ioasys.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TUsuario");
            builder.HasKey(x => x.IdUsuario);
            builder.Property(x => x.NomeUsuario).HasColumnType("varchar(250)").IsRequired(); 
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataModificacao).HasColumnType("datetime");
            builder.Property(x => x.DataExclusao).HasColumnType("datetime");
            builder.Property(x => x.IdCriadoPor);
            builder.Property(x => x.IdAtualizadoPor);
            builder.Property(x => x.IdExcluidoPor);


            builder.Ignore(x => x.ValidationResult);      
        }
    }
}
