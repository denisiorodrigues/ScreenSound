using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Dados.Banco;

public static class DALExtensions
{
    public static List<Artista> ListarComAvaliacoes(this DAL<Artista> dal)
    {
        return dal.context.Artistas.Include(a => a.Avaliacoes).ToList();
    }

    public static Musica? RecuperarMusicaPorNomeComGeneros(this DAL<Musica> dal, string nome)
    {
        return dal.context.Musicas
            .Include(m => m.Generos)
            .FirstOrDefault(a => a.Nome.ToLower().Equals(nome.ToLower()));
    }

    public static Artista? RecuperarArtistaComAvaliacoes(this DAL<Artista> dal, int id)
    {
        return dal.context.Artistas
            .Include(a => a.Avaliacoes)
            .FirstOrDefault(a => a.Id == id);
    }
}