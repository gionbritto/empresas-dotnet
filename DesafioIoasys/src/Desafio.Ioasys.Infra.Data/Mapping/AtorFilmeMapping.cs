using Desafio.Ioasys.Domain.Entities.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Mapping
{
    public class AtorFilmeMapping : IEntityTypeConfiguration<AtorFilme>
    {
        public void Configure(EntityTypeBuilder<AtorFilme> builder)
        {

            builder.ToTable("TAtorFilme");
            builder.HasKey(x => x.IdAtorFilme);
            builder.Property(x => x.IdFilme).IsRequired();
            builder.Property(x => x.IdAtor).IsRequired();

            builder.HasOne(x => x.Filme).WithMany(x => x.AtoresFilme).HasForeignKey(x => x.IdFilme).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Ator).WithMany(x => x.AtorFilmes).HasForeignKey(x => x.IdAtor).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
