﻿// <auto-generated />
using System;
using Desafio.Ioasys.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio.Ioasys.Infra.Data.Migrations
{
    [DbContext(typeof(DesafioIOContext))]
    [Migration("20201015001119_criar_banco")]
    partial class criar_banco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.Ator", b =>
                {
                    b.Property<Guid>("IdAtor")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataModificacao")
                        .HasColumnType("datetime");

                    b.Property<string>("IdAtualizadoPor");

                    b.Property<string>("IdCriadoPor");

                    b.Property<string>("IdExcluidoPor");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdAtor");

                    b.ToTable("TAtor");
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.AtorFilme", b =>
                {
                    b.Property<Guid>("IdAtorFilme")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IdAtor");

                    b.Property<Guid>("IdFilme");

                    b.HasKey("IdAtorFilme");

                    b.HasIndex("IdAtor");

                    b.HasIndex("IdFilme");

                    b.ToTable("TAtorFilme");
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.Diretor", b =>
                {
                    b.Property<Guid>("IdDiretor")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataModificacao")
                        .HasColumnType("datetime");

                    b.Property<string>("IdAtualizadoPor");

                    b.Property<string>("IdCriadoPor");

                    b.Property<string>("IdExcluidoPor");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdDiretor");

                    b.ToTable("TDiretor");
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.DiretorFilme", b =>
                {
                    b.Property<Guid>("IdDiretorFilme")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IdDiretor");

                    b.Property<Guid>("IdFilme");

                    b.HasKey("IdDiretorFilme");

                    b.HasIndex("IdDiretor");

                    b.HasIndex("IdFilme");

                    b.ToTable("TDiretorFilme");
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.Filme", b =>
                {
                    b.Property<Guid>("IdFilme")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataModificacao")
                        .HasColumnType("datetime");

                    b.Property<string>("IdAtualizadoPor");

                    b.Property<string>("IdCriadoPor");

                    b.Property<string>("IdExcluidoPor");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdFilme");

                    b.ToTable("TFilme");
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.Genero", b =>
                {
                    b.Property<Guid>("IdGenero")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataModificacao")
                        .HasColumnType("datetime");

                    b.Property<string>("IdAtualizadoPor");

                    b.Property<string>("IdCriadoPor");

                    b.Property<string>("IdExcluidoPor");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdGenero");

                    b.ToTable("TGenero");
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.GeneroFilme", b =>
                {
                    b.Property<Guid>("IdGeneroFilme")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IdFilme");

                    b.Property<Guid>("IdGenero");

                    b.HasKey("IdGeneroFilme");

                    b.HasIndex("IdFilme");

                    b.HasIndex("IdGenero");

                    b.ToTable("TGeneroFilme");
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.AtorFilme", b =>
                {
                    b.HasOne("Desafio.Ioasys.Domain.Entities.Filmes.Ator", "Ator")
                        .WithMany("AtorFilmes")
                        .HasForeignKey("IdAtor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Desafio.Ioasys.Domain.Entities.Filmes.Filme", "Filme")
                        .WithMany("AtorFilmes")
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.DiretorFilme", b =>
                {
                    b.HasOne("Desafio.Ioasys.Domain.Entities.Filmes.Diretor", "Diretor")
                        .WithMany("DiretorFilmes")
                        .HasForeignKey("IdDiretor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Desafio.Ioasys.Domain.Entities.Filmes.Filme", "Filme")
                        .WithMany("DiretorFilmes")
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Desafio.Ioasys.Domain.Entities.Filmes.GeneroFilme", b =>
                {
                    b.HasOne("Desafio.Ioasys.Domain.Entities.Filmes.Filme", "Filme")
                        .WithMany("GeneroFilmes")
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Desafio.Ioasys.Domain.Entities.Filmes.Genero", "Genero")
                        .WithMany("GeneroFilmes")
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}