using Microsoft.EntityFrameworkCore;
using ScreenSound.Dados.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir detalhes do artista");
        Console.Write("Digite o ano de lançamento da música: ");
        var anoLancamento = Console.ReadLine()!;
        var context = CriarContexto();
        var musicaDAL = new DAL<Musica>(context);
        var listaMusicasAnoLancamento =
            musicaDAL.ListarPor(a => a.AnoLancamento.Value == Convert.ToInt32(anoLancamento));
        if (listaMusicasAnoLancamento.Any())
        {
            Console.WriteLine($"\nMúsicas do Ano {anoLancamento}:");
            foreach (var musica in listaMusicasAnoLancamento) musica.ExibirFichaTecnica();

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO ano {anoLancamento} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private ScreenSoundContext CriarContexto()
    {
        var options = new DbContextOptionsBuilder<ScreenSoundContext>().Options;

        return new ScreenSoundContext(options);
    }
}