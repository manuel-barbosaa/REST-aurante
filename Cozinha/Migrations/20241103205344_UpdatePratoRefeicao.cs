using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_aurante.Cozinha.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePratoRefeicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refeicao_Ementas_EmentaId",
                table: "Refeicao");

            migrationBuilder.DropIndex(
                name: "IX_Refeicao_EmentaId",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "EmentaId",
                table: "Refeicao");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Ementas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TipoRefeicaoId",
                table: "Ementas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Ementas_TipoRefeicaoId",
                table: "Ementas",
                column: "TipoRefeicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ementas_TipoRefeicao_TipoRefeicaoId",
                table: "Ementas",
                column: "TipoRefeicaoId",
                principalTable: "TipoRefeicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ementas_TipoRefeicao_TipoRefeicaoId",
                table: "Ementas");

            migrationBuilder.DropIndex(
                name: "IX_Ementas_TipoRefeicaoId",
                table: "Ementas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Ementas");

            migrationBuilder.DropColumn(
                name: "TipoRefeicaoId",
                table: "Ementas");

            migrationBuilder.AddColumn<int>(
                name: "EmentaId",
                table: "Refeicao",
                type: "INTEGER",
                nullable: true);

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
    }
}
