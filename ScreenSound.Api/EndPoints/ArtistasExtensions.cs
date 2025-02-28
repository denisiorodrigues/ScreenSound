using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Requests;
using ScreenSound.Api.Response;
using ScreenSound.Dados.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class ArtistasExtensions
{
    public static void AddEndPointsArtistas(this WebApplication app)
    {
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
        {
            return Results.Ok(dal.Listar().Select(a => new ArtistaResponse(a.Id, a.Nome, a.Bio, a.FotoPerfil)));
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));
            if (artista == null)
            {
                return Results.NotFound();
            }

            var artistaResponse = new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);

            return Results.Ok(artistaResponse);
        });

        app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {
            var artista = new Artista(artistaRequest.nome, artistaRequest.bio);
            dal.Adicionar(artista);

            return Results.Ok();
        });

        app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequest) =>
        {
            var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequest.id);
            if (artistaAAtualizar == null)
            {
                return Results.NotFound();
            }

            artistaAAtualizar.Nome = artistaRequest.nome;
            artistaAAtualizar.Bio = artistaRequest.bio;
            dal.Atualizar(artistaAAtualizar);

            return Results.Ok();
        });

        app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
        {
            var artistaADeletar = dal.RecuperarPor(a => a.Id == id);
            if (artistaADeletar == null)
            {
                return Results.NotFound();
            }

            dal.Deletar(artistaADeletar);

            return Results.NoContent();
        });
    }
}
