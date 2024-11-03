using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_aurante.Cozinha.Migrations
{
    /// <inheritdoc />
    public partial class AddEmentaIdToRefeicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmentaId",
                table: "Refeicao",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ementas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Frequencia = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ementas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_EmentaId",
                table: "Refeicao",
                column: "EmentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refeicao_Ementas_EmentaId",
                table: "Refeicao",
                column: "EmentaId",
                principalTable: "Ementas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refeicao_Ementas_EmentaId",
                table: "Refeicao");

            migrationBuilder.DropTable(
                name: "Ementas");

            migrationBuilder.DropIndex(
                name: "IX_Refeicao_EmentaId",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "EmentaId",
                table: "Refeicao");
        }
    }
}
