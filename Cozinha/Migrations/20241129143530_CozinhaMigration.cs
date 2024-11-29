using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_aurante.Cozinha.Migrations
{
    /// <inheritdoc />
    public partial class CozinhaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ementas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Frequencia = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ementas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRefeicao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRefeicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPrato",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pratos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    IsAtivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    TipoPratoId = table.Column<long>(type: "INTEGER", nullable: false),
                    Receita = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pratos_TiposPrato_TipoPratoId",
                        column: x => x.TipoPratoId,
                        principalTable: "TiposPrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CategoriaAlimenticia = table.Column<string>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    PratoId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Pratos_PratoId",
                        column: x => x.PratoId,
                        principalTable: "Pratos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PratoId = table.Column<long>(type: "INTEGER", nullable: false),
                    TipoRefeicaoId = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmentaId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refeicao_Ementas_EmentaId",
                        column: x => x.EmentaId,
                        principalTable: "Ementas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Refeicao_Pratos_PratoId",
                        column: x => x.PratoId,
                        principalTable: "Pratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Refeicao_TipoRefeicao_TipoRefeicaoId",
                        column: x => x.TipoRefeicaoId,
                        principalTable: "TipoRefeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PratoId",
                table: "Ingredientes",
                column: "PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_TipoPratoId",
                table: "Pratos",
                column: "TipoPratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_EmentaId",
                table: "Refeicao",
                column: "EmentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_PratoId",
                table: "Refeicao",
                column: "PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_TipoRefeicaoId",
                table: "Refeicao",
                column: "TipoRefeicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Refeicao");

            migrationBuilder.DropTable(
                name: "Ementas");

            migrationBuilder.DropTable(
                name: "Pratos");

            migrationBuilder.DropTable(
                name: "TipoRefeicao");

            migrationBuilder.DropTable(
                name: "TiposPrato");
        }
    }
}
