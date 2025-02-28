using Microsoft.AspNetCore.Mvc;
using ScreenSound.Dados.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class ArtistasExtensions
{
    public static void AddEndPointsArtistas(this WebApplication app)
    {
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));
            if (artista == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(artista);
        });

        app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
        {
            dal.Adicionar(artista);

            return Results.Ok();
        });

        app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
        {
            var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artista.Id);
            if (artistaAAtualizar == null)
            {
                return Results.NotFound();
            }

            artistaAAtualizar.Nome = artista.Nome;
            artistaAAtualizar.Bio = artista.Bio;
            artistaAAtualizar.FotoPerfil = artista.FotoPerfil;
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
