using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_aurante.Cozinha.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTipoPratoMappingNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PratoId = table.Column<long>(type: "INTEGER", nullable: false),
                    TipoRefeicaoId = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.Id);
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
                name: "Refeicao");
        }
    }
}
