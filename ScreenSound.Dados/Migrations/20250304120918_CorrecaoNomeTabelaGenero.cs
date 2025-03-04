using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoNomeTabelaGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroMusica_Genereos_GenerosId",
                table: "GeneroMusica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genereos",
                table: "Genereos");

            migrationBuilder.RenameTable(
                name: "Genereos",
                newName: "Generos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroMusica_Generos_GenerosId",
                table: "GeneroMusica",
                column: "GenerosId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroMusica_Generos_GenerosId",
                table: "GeneroMusica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genereos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genereos",
                table: "Genereos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroMusica_Genereos_GenerosId",
                table: "GeneroMusica",
                column: "GenerosId",
                principalTable: "Genereos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
