using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Ioasys.Infra.Data.Migrations
{
    public partial class update_votos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "TFilme",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TUsuario",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdCriadoPor = table.Column<string>(nullable: true),
                    IdAtualizadoPor = table.Column<string>(nullable: true),
                    IdExcluidoPor = table.Column<string>(nullable: true),
                    NomeUsuario = table.Column<string>(type: "varchar(250)", nullable: false),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUsuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "TVoto",
                columns: table => new
                {
                    IdVoto = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdAtualizadoPor = table.Column<string>(nullable: true),
                    IdFilme = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<string>(nullable: false),
                    Pontuacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVoto", x => x.IdVoto);
                    table.ForeignKey(
                        name: "FK_TVoto_TFilme_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "TFilme",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TVoto_TUsuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "TUsuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVoto_IdFilme",
                table: "TVoto",
                column: "IdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_TVoto_IdUsuario",
                table: "TVoto",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVoto");

            migrationBuilder.DropTable(
                name: "TUsuario");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "TFilme");
        }
    }
}
