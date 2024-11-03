using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_aurante.Cozinha.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePratoIngredienteRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Pratos_PratoId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_TiposPrato_TipoPratoId",
                table: "Pratos");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_PratoId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "PratoId",
                table: "Ingredientes");

            migrationBuilder.AlterColumn<long>(
                name: "TipoPratoId",
                table: "Pratos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Pratos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "PratoIngrediente",
                columns: table => new
                {
                    IngredienteId = table.Column<long>(type: "INTEGER", nullable: false),
                    PratoId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PratoIngrediente", x => new { x.IngredienteId, x.PratoId });
                    table.ForeignKey(
                        name: "FK_PratoIngrediente_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PratoIngrediente_Pratos_PratoId",
                        column: x => x.PratoId,
                        principalTable: "Pratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_PratoIngrediente_PratoId",
                table: "PratoIngrediente",
                column: "PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_PratoId",
                table: "Refeicao",
                column: "PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_TipoRefeicaoId",
                table: "Refeicao",
                column: "TipoRefeicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_TiposPrato_Id",
                table: "Pratos",
                column: "Id",
                principalTable: "TiposPrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_TiposPrato_TipoPratoId",
                table: "Pratos",
                column: "TipoPratoId",
                principalTable: "TiposPrato",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_TiposPrato_Id",
                table: "Pratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_TiposPrato_TipoPratoId",
                table: "Pratos");

            migrationBuilder.DropTable(
                name: "PratoIngrediente");

            migrationBuilder.DropTable(
                name: "Refeicao");

            migrationBuilder.AlterColumn<long>(
                name: "TipoPratoId",
                table: "Pratos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Pratos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<long>(
                name: "PratoId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PratoId",
                table: "Ingredientes",
                column: "PratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Pratos_PratoId",
                table: "Ingredientes",
                column: "PratoId",
                principalTable: "Pratos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_TiposPrato_TipoPratoId",
                table: "Pratos",
                column: "TipoPratoId",
                principalTable: "TiposPrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
