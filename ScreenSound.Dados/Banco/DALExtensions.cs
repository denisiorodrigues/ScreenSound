using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Dados.Banco;

public static class DALExtensions
{
    public static Musica? RecuperarMusicaPorNomeComGeneros(this DAL<Musica> dal, string nome)
    {
        return dal.context.Musicas
            .Include(m => m.Generos)
            .FirstOrDefault(a => a.Nome.ToLower().Equals(nome.ToLower()));
    }
}