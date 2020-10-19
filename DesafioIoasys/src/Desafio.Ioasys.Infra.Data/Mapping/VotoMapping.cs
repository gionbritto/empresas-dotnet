using Desafio.Ioasys.Domain.Entities.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Mapping
{
    public class VotoMapping : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {

            builder.ToTable("TVoto");
            builder.HasKey(x => x.IdVoto);
            builder.Property(x => x.IdFilme).IsRequired();
            builder.Property(x => x.IdUsuario).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataModificacao).HasColumnType("datetime");
            builder.Property(x => x.DataExclusao).HasColumnType("datetime");            
            builder.Property(x => x.IdAtualizadoPor);

            builder.HasOne(x => x.Filme).WithMany(x => x.Votos).HasForeignKey(x => x.IdFilme).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Usuario).WithMany(x => x.Votos).HasForeignKey(x => x.IdUsuario).OnDelete(DeleteBehavior.Restrict);
                        
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.IdCriadoPor);
            builder.Ignore(x => x.IdExcluidoPor);
        }
    }
}
