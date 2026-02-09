using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Dados.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelaMusicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Djavan
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Flor de Lis', 1976, (SELECT Id FROM Artistas WHERE Nome = 'Djavan' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Oceano', 1989, (SELECT Id FROM Artistas WHERE Nome = 'Djavan' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Se...', 1992, (SELECT Id FROM Artistas WHERE Nome = 'Djavan' LIMIT 1))");

            // Foo Fighters
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Everlong', 1997, (SELECT Id FROM Artistas WHERE Nome = 'Foo Fighters' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Learn to Fly', 1999, (SELECT Id FROM Artistas WHERE Nome = 'Foo Fighters' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Best of You', 2005, (SELECT Id FROM Artistas WHERE Nome = 'Foo Fighters' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('The Pretender', 2007, (SELECT Id FROM Artistas WHERE Nome = 'Foo Fighters' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('My Hero', 1997, (SELECT Id FROM Artistas WHERE Nome = 'Foo Fighters' LIMIT 1))");

            // Pitty
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Máscara', 2003, (SELECT Id FROM Artistas WHERE Nome = 'Pitty' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Admirável Chip Novo', 2003, (SELECT Id FROM Artistas WHERE Nome = 'Pitty' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Me Adora', 2009, (SELECT Id FROM Artistas WHERE Nome = 'Pitty' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Equalize', 2003, (SELECT Id FROM Artistas WHERE Nome = 'Pitty' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Na Sua Estante', 2006, (SELECT Id FROM Artistas WHERE Nome = 'Pitty' LIMIT 1))");

            // Gilberto Gil
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Aquele Abraço', 1969, (SELECT Id FROM Artistas WHERE Nome = 'Gilberto Gil' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Andar com Fé', 1982, (SELECT Id FROM Artistas WHERE Nome = 'Gilberto Gil' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Palco', 2003, (SELECT Id FROM Artistas WHERE Nome = 'Gilberto Gil' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Vamos Fugir', 1984, (SELECT Id FROM Artistas WHERE Nome = 'Gilberto Gil' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Toda Menina Baiana', 1979, (SELECT Id FROM Artistas WHERE Nome = 'Gilberto Gil' LIMIT 1))");

            // Roque Abílio
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Coração de Boiadeiro', 1995, (SELECT Id FROM Artistas WHERE Nome = 'Roque Abílio' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('A Volta do Boiadeiro', 1995, (SELECT Id FROM Artistas WHERE Nome = 'Roque Abílio' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('O Rei do Gado', 1996, (SELECT Id FROM Artistas WHERE Nome = 'Roque Abílio' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Peão Apaixonado', 2000, (SELECT Id FROM Artistas WHERE Nome = 'Roque Abílio' LIMIT 1))");
            migrationBuilder.Sql("INSERT INTO Musicas (Nome, AnoLancamento, ArtistaId) VALUES ('Viola Divina', 1995, (SELECT Id FROM Artistas WHERE Nome = 'Roque Abílio' LIMIT 1))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas");
        }
    }
}