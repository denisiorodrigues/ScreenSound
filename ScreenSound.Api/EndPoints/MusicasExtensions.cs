using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Requests;
using ScreenSound.Api.Response;
using ScreenSound.Dados.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class MusicasExtensions
{
    public static void AddEndPointsMusicas(this WebApplication app)
    {

        app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
        {
            return Results.Ok(dal.Listar().Select(m => new MusicaResponse(m.Id, m.Nome, m.ArtistaId, m.Artista?.Nome)));
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));
            if (musica == null)
            {
                return Results.NotFound();
            }

            var musicaResponse = new MusicaResponse(musica.Id, musica.Nome, musica.ArtistaId, musica.Artista?.Nome);

            return Results.Ok(musicaResponse);
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

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
        {
            var musica = new Musica(musicaRequest.nome, musicaRequest.anoLancamento);
            musica.ArtistaId = musicaRequest.ArtistaId;
            dal.Adicionar(musica);

            return Results.Ok();
        });

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequestEdit musicaRequest
            ) =>
        {
            var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musicaRequest.id);
            if (musicaAAtualizar == null)
            {
                return Results.NotFound();
            }

            musicaAAtualizar.Nome = musicaRequest.nome;
            musicaAAtualizar.AnoLancamento = musicaRequest.anoLancamento;
            musicaAAtualizar.ArtistaId = musicaRequest.ArtistaId;
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
