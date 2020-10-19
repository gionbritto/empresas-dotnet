using Desafio.Ioasys.Domain;
using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Infra.Data.Context
{
    public class DesafioIOContext : DbContext
    {
        public DesafioIOContext(DbContextOptions<DesafioIOContext> options)
           : base(options)
        {

        }

        public DbSet<Filme> TFilme { get; set; }
        public DbSet<Diretor> TDiretor { get; set; }
        public DbSet<Genero> TGenero { get; set; }
        public DbSet<Ator> TAtor { get; set; }
        public DbSet<DiretorFilme> TDiretorFilme { get; set; }
        public DbSet<GeneroFilme> TGeneroFilme { get; set; }
        public DbSet<AtorFilme> TAtorFilme { get; set; }
        public DbSet<Voto> TVoto { get; set; }
        public DbSet<Usuario> TUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FilmeMapping());
            modelBuilder.ApplyConfiguration(new DiretorMapping());
            modelBuilder.ApplyConfiguration(new GeneroMapping());
            modelBuilder.ApplyConfiguration(new AtorMapping());
            modelBuilder.ApplyConfiguration(new DiretorFilmeMapping());
            modelBuilder.ApplyConfiguration(new GeneroFilmeMapping());
            modelBuilder.ApplyConfiguration(new AtorFilmeMapping());
            modelBuilder.ApplyConfiguration(new VotoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                    E.Property("DataCadastro").CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                    E.Property("DataModificacao").CurrentValue = DateTime.Now;
                    E.Property("DataCadastro").IsModified = false;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
           
                optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"));          
        }
    }
}
