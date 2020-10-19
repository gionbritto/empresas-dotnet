using Desafio.Ioasys.Domain.Entities.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Mapping
{
    public class DiretorFilmeMapping : IEntityTypeConfiguration<DiretorFilme>
    {
        public void Configure(EntityTypeBuilder<DiretorFilme> builder)
        {

            builder.ToTable("TDiretorFilme");
            builder.HasKey(x => x.IdDiretorFilme);
            builder.Property(x => x.IdFilme).IsRequired();
            builder.Property(x => x.IdDiretor).IsRequired();

            builder.HasOne(x => x.Filme).WithMany(x => x.DiretoresFilme).HasForeignKey(x => x.IdFilme).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Diretor).WithMany(x => x.DiretorFilmes).HasForeignKey(x => x.IdDiretor).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
