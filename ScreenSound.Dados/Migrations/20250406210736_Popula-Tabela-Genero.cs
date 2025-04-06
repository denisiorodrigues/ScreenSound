using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Dados.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTabelaGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Generos", new string[] { "Nome", "Descricao" }, new object[] { "MPB", "Musica popular braileira" });
            migrationBuilder.InsertData("Generos", new string[] { "Nome", "Descricao" }, new object[] { "POP", "Musicas genero popular" });
            migrationBuilder.InsertData("Generos", new string[] { "Nome", "Descricao" }, new object[] { "ROCK", "Musica underground" });
            migrationBuilder.InsertData("Generos", new string[] { "Nome", "Descricao" }, new object[] { "Eletronica", "Musica instrumentros eletronicos" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Generos");
        }
    }
}
