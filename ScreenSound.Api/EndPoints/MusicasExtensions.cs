using Microsoft.AspNetCore.Mvc;
using ScreenSound.Dados.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class MusicasExtensions
{
    public static void AddEndPointsMusicas(this WebApplication app)
    {

        app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));
            if (musica == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(musica);
        });

        app.MapGet("/Musicas/Artista/{artistaId}", ([FromServices] DAL<Musica> dal, int artistaId) =>
        {
            var musicas = dal.ListarPor(a => a.Artista.Id == artistaId);
            if (musicas == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(musicas);
        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
        {
            dal.Adicionar(musica);

            return Results.Ok();
        });

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
        {
            var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musica.Id);
            if (musicaAAtualizar == null)
            {
                return Results.NotFound();
            }

            musicaAAtualizar.Nome = musica.Nome;
            musicaAAtualizar.AnoLancamento = musica.AnoLancamento;
            musicaAAtualizar.Artista = musica.Artista;
            dal.Atualizar(musicaAAtualizar);

            return Results.Ok();
        });

        app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
        {
            var musicaADeletar = dal.RecuperarPor(a => a.Id == id);
            if (musicaADeletar == null)
            {
                return Results.NotFound();
            }

            dal.Deletar(musicaADeletar);

            return Results.NoContent();
        });
    }
}
