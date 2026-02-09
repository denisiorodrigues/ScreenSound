using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Dados.Migrations
{
    /// <inheritdoc />
    public partial class InserindoCemArtistas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[,] {
                { "Djavan", "Djavan Caetano Viana é um cantor, compositor, arranjador, produtor musical, empresário, violonista e ex-futebolista brasileiro.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Roberto Carlos", "Roberto Carlos Braga é um cantor, compositor e empresário brasileiro, conhecido como o Rei da música latina.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Chico Buarque", "Francisco Buarque de Hollanda é um músico, dramaturgo, escritor, ator e político brasileiro.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Caetano Veloso", "Caetano Emanuel Viana Teles Veloso é um cantor, compositor, produtor musical e escritor brasileiro.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Gilberto Gil", "Gilberto Passos Gil Moreira é um cantor, compositor, multi-instrumentista, produtor musical e político brasileiro.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Milton Nascimento", "Milton Nascimento é um cantor, compositor e multi-instrumentista brasileiro, reconhecido mundialmente como um dos maiores e mais influentes músicos da América Latina.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Elis Regina", "Elis Regina Carvalho Costa foi uma cantora brasileira, considerada por muitos a maior cantora do Brasil.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Tom Jobim", "Antônio Carlos Brasileiro de Almeida Jobim, conhecido como Tom Jobim, foi um cantor, compositor, pianista, maestro, arranjador e violonista brasileiro.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Tim Maia", "Tim Maia foi um cantor, compositor, maestro, produtor musical, empresário e multi-instrumentista brasileiro, responsável pela introdução dos gêneros soul, funk e disco na MPB, e reconhecido como um dos maiores ícones da música brasileira.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Gal Costa", "Maria da Graça Costa Penna Burgos, conhecida como Gal Costa, é uma cantora brasileira de MPB.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Raul Seixas", "Raul Santos Seixas foi um cantor, compositor, produtor e músico brasileiro, frequentemente considerado um dos maiores e mais originais ícones do rock no Brasil.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Rita Lee", "Rita Lee Jones é uma cantora, compositora, multi-instrumentista, atriz, escritora e ativista brasileira.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Maria Bethânia", "Maria Bethânia Vianna Telles Veloso é uma cantora brasileira, conhecida por sua intensidade interpretativa.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Ney Matogrosso", "Ney de Souza Pereira é um cantor, diretor, ator e compositor brasileiro, conhecido por sua voz aguda e performances teatrais.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Luiz Gonzaga", "Luiz Gonzaga do Nascimento foi um cantor, compositor e multi-instrumentista brasileiro, conhecido como o Rei do Baião.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Jorge Ben Jor", "Jorge Duílio Lima Menezes é um cantor, compositor, guitarrista e multi-instrumentista brasileiro, conhecido por seu estilo musical único que mistura samba, funk, rock e outros gêneros.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Alceu Valença", "Alceu Paiva Valença é um cantor, compositor e multi-instrumentista brasileiro, conhecido por sua mistura de ritmos nordestinos com rock e outros gêneros.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Zeca Pagodinho", "Jessé Gomes da Silva Filho, conhecido como Zeca Pagodinho, é um cantor e compositor brasileiro de samba.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Cazuza", "Agenor de Miranda Araújo Neto, conhecido como Cazuza, foi um cantor, compositor e poeta brasileiro.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Marisa Monte", "Marisa de Azevedo Monte é uma cantora, compositora e produtora musical brasileira, conhecida por sua voz suave e estilo musical eclético.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { "Cartola", "Agenor de Oliveira, conhecido como Cartola, foi um cantor, compositor e violonista brasileiro, considerado um dos maiores sambistas da história.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" },
                { 
                    "Foo Fighters", 
                    "Banda de rock americana formada por Dave Grohl em 1994, conhecida por hits como 'Everlong' e por sua energia visceral no palco.", 
                    "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" 
                },
                { 
                    "Pitty", 
                    "Cantora, compositora e instrumentista brasileira, uma das maiores representantes do rock nacional contemporâneo.", 
                    "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" 
                },
                { 
                    "Roque Abílio", 
                    "Artista brasileiro focado em gêneros tradicionais e sertanejo raiz, com obras que exaltam a vida no campo e a cultura caipira.", 
                    "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" 
                }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Djavan'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Roberto Carlos'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Chico Buarque'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Caetano Veloso'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Gilberto Gil'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Milton Nascimento'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Elis Regina'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Tom Jobim'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Tim Maia'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Gal Costa'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Raul Seixas'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Rita Lee'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Maria Bethânia'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Ney Matogrosso'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Luiz Gonzaga'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Jorge Ben Jor'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Alceu Valença'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Zeca Pagodinho'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Cazuza'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Marisa Monte'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Cartola'");
            migrationBuilder.Sql("DELETE FROM Artistas WHERE Nome = 'Clara Nunes'");
        }
    }
}
