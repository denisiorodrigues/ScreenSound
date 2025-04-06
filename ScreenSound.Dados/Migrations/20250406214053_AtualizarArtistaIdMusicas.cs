using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarArtistaIdMusicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Atualizar ""ArtistaId"" para Djavan
            migrationBuilder.Sql(@"
                UPDATE ""Musicas""
                SET ""ArtistaId"" = 1
                WHERE ""Nome"" IN ('Flor de Lis', 'Oceano', 'Se...')
            ");

            // Atualizar ""ArtistaId"" para Foo Fighters
            migrationBuilder.Sql(@"
                UPDATE ""Musicas""
                SET ""ArtistaId"" = 2
                WHERE ""Nome"" IN ('Everlong', 'Learn to Fly', 'Best of You', 'The Pretender', 'My Hero')
            ");

            // Atualizar ""ArtistaId"" para Pitty
            migrationBuilder.Sql(@"
                UPDATE ""Musicas""
                SET ""ArtistaId"" = 3
                WHERE ""Nome"" IN ('Máscara', 'Admirável Chip Novo', 'Me Adora', 'Equalize', 'Na Sua Estante')
            ");

            // Atualizar ""ArtistaId"" para Gilberto Gil
            migrationBuilder.Sql(@"
                UPDATE ""Musicas""
                SET ""ArtistaId"" = 4
                WHERE ""Nome"" IN ('Aquele Abraço', 'Andar com Fé', 'Palco', 'Vamos Fugir', 'Toda Menina Baiana')
            ");

            // Atualizar ""ArtistaId"" para Roque Abílio
            migrationBuilder.Sql(@"
                UPDATE ""Musicas""
                SET ""ArtistaId"" = 7
                WHERE ""Nome"" IN ('Coração de Boiadeiro', 'A Volta do Boiadeiro', 'O Rei do Gado', 'Peão Apaixonado', 'Viola Divina')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE ""Musicas""
                SET ""ArtistaId"" = NULL
                WHERE ""ArtistaId"" IN (1, 2, 3, 4, 7)
            ");
        }
    }
}
