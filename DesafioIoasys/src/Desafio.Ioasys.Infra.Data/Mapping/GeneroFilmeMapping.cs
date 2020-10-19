using Desafio.Ioasys.Domain.Entities.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Mapping
{
    public class GeneroFilmeMapping : IEntityTypeConfiguration<GeneroFilme>
    {
        public void Configure(EntityTypeBuilder<GeneroFilme> builder)
        {

            builder.ToTable("TGeneroFilme");
            builder.HasKey(x => x.IdGeneroFilme);
            builder.Property(x => x.IdFilme).IsRequired();
            builder.Property(x => x.IdGenero).IsRequired();

            builder.HasOne(x => x.Filme).WithMany(x => x.GenerosFilme).HasForeignKey(x => x.IdFilme).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Genero).WithMany(x => x.GeneroFilmes).HasForeignKey(x => x.IdGenero).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
