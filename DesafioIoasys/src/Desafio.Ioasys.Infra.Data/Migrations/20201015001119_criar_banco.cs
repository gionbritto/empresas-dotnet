using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Ioasys.Infra.Data.Migrations
{
    public partial class criar_banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAtor",
                columns: table => new
                {
                    IdAtor = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdCriadoPor = table.Column<string>(nullable: true),
                    IdAtualizadoPor = table.Column<string>(nullable: true),
                    IdExcluidoPor = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAtor", x => x.IdAtor);
                });

            migrationBuilder.CreateTable(
                name: "TDiretor",
                columns: table => new
                {
                    IdDiretor = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdCriadoPor = table.Column<string>(nullable: true),
                    IdAtualizadoPor = table.Column<string>(nullable: true),
                    IdExcluidoPor = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDiretor", x => x.IdDiretor);
                });

            migrationBuilder.CreateTable(
                name: "TFilme",
                columns: table => new
                {
                    IdFilme = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdCriadoPor = table.Column<string>(nullable: true),
                    IdAtualizadoPor = table.Column<string>(nullable: true),
                    IdExcluidoPor = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFilme", x => x.IdFilme);
                });

            migrationBuilder.CreateTable(
                name: "TGenero",
                columns: table => new
                {
                    IdGenero = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdCriadoPor = table.Column<string>(nullable: true),
                    IdAtualizadoPor = table.Column<string>(nullable: true),
                    IdExcluidoPor = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGenero", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "TAtorFilme",
                columns: table => new
                {
                    IdAtorFilme = table.Column<Guid>(nullable: false),
                    IdFilme = table.Column<Guid>(nullable: false),
                    IdAtor = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAtorFilme", x => x.IdAtorFilme);
                    table.ForeignKey(
                        name: "FK_TAtorFilme_TAtor_IdAtor",
                        column: x => x.IdAtor,
                        principalTable: "TAtor",
                        principalColumn: "IdAtor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAtorFilme_TFilme_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "TFilme",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TDiretorFilme",
                columns: table => new
                {
                    IdDiretorFilme = table.Column<Guid>(nullable: false),
                    IdFilme = table.Column<Guid>(nullable: false),
                    IdDiretor = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDiretorFilme", x => x.IdDiretorFilme);
                    table.ForeignKey(
                        name: "FK_TDiretorFilme_TDiretor_IdDiretor",
                        column: x => x.IdDiretor,
                        principalTable: "TDiretor",
                        principalColumn: "IdDiretor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TDiretorFilme_TFilme_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "TFilme",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TGeneroFilme",
                columns: table => new
                {
                    IdGeneroFilme = table.Column<Guid>(nullable: false),
                    IdFilme = table.Column<Guid>(nullable: false),
                    IdGenero = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGeneroFilme", x => x.IdGeneroFilme);
                    table.ForeignKey(
                        name: "FK_TGeneroFilme_TFilme_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "TFilme",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TGeneroFilme_TGenero_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "TGenero",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAtorFilme_IdAtor",
                table: "TAtorFilme",
                column: "IdAtor");

            migrationBuilder.CreateIndex(
                name: "IX_TAtorFilme_IdFilme",
                table: "TAtorFilme",
                column: "IdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_TDiretorFilme_IdDiretor",
                table: "TDiretorFilme",
                column: "IdDiretor");

            migrationBuilder.CreateIndex(
                name: "IX_TDiretorFilme_IdFilme",
                table: "TDiretorFilme",
                column: "IdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_TGeneroFilme_IdFilme",
                table: "TGeneroFilme",
                column: "IdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_TGeneroFilme_IdGenero",
                table: "TGeneroFilme",
                column: "IdGenero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAtorFilme");

            migrationBuilder.DropTable(
                name: "TDiretorFilme");

            migrationBuilder.DropTable(
                name: "TGeneroFilme");

            migrationBuilder.DropTable(
                name: "TAtor");

            migrationBuilder.DropTable(
                name: "TDiretor");

            migrationBuilder.DropTable(
                name: "TFilme");

            migrationBuilder.DropTable(
                name: "TGenero");
        }
    }
}
