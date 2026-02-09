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
        var groupBuilder = app.MapGroup("artistas")
            .RequireAuthorization()
            .WithTags("Artistas");

        groupBuilder
            .MapGet("",
                ([FromServices] DAL<Artista> dal) => { return Results.Ok(EntityListToResponseList(dal.Listar())); })
            .RequireAuthorization();

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));
            if (artista == null) return Results.NotFound();

            return Results.Ok(EntityToResponse(artista));
        }).RequireAuthorization();

        groupBuilder.MapPost("",
            async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal,
                [FromBody] ArtistaRequest artistaRequest) =>
            {
                var nome = artistaRequest.nome.Trim();
                var imagemArtista = nome + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpeg";
                var path = Path.Combine(env.ContentRootPath, "wwwroot", "images", "artistas", imagemArtista);
                using var ms = new MemoryStream(Convert.FromBase64String(artistaRequest.fotoPerfil!));
                using var file = new FileStream(path, FileMode.Create);

                await ms.CopyToAsync(file);

                var artista = new Artista(artistaRequest.nome, artistaRequest.bio)
                {
                    FotoPerfil = $"imagens/artistas/{imagemArtista}"
                };

                dal.Adicionar(artista);

                return Results.Ok();
            }).RequireAuthorization();

        groupBuilder.MapPut("",
            ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequest) =>
            {
                var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequest.id);
                if (artistaAAtualizar == null) return Results.NotFound();

                artistaAAtualizar.Nome = artistaRequest.nome;
                artistaAAtualizar.Bio = artistaRequest.bio;
                dal.Atualizar(artistaAAtualizar);

                return Results.Ok();
            }).RequireAuthorization();

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Artista> dal, int id) =>
        {
            var artistaADeletar = dal.RecuperarPor(a => a.Id == id);
            if (artistaADeletar == null) return Results.NotFound();

            dal.Deletar(artistaADeletar);

            return Results.NoContent();
        }).RequireAuthorization();
    }

    private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
    {
        return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
    }

    private static ArtistaResponse EntityToResponse(Artista artista)
    {
        return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
    }
}