using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Requests;
using ScreenSound.Api.Response;
using ScreenSound.Dados.Banco;
using ScreenSound.Dados.Modelos;
using ScreenSound.Modelos;
using System.Security.Claims;

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
                ([FromServices] DAL<Artista> dal) => { return Results.Ok(EntityListToResponseList(dal.Listar())); });

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));
            if (artista == null) return Results.NotFound();

            return Results.Ok(EntityToResponse(artista));
        });

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
            });

        groupBuilder.MapPut("",
            ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequest) =>
            {
                var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequest.id);
                if (artistaAAtualizar == null) return Results.NotFound();

                artistaAAtualizar.Nome = artistaRequest.nome;
                artistaAAtualizar.Bio = artistaRequest.bio;
                dal.Atualizar(artistaAAtualizar);

                return Results.Ok();
            });

        groupBuilder.MapPost("avaliacao", async (HttpContext context, 
            [FromServices] DAL<Artista> artistaDAL,
            [FromServices] UserManager<PessoaComAcesso> pessoaDAL,
            [FromBody] AvaliacaoArtistaRequest avaliacaoRequest) =>
        {
            var artistaAAtualizar = artistaDAL.RecuperarArtistaComAvaliacoes(avaliacaoRequest.ArtistaId);
            if (artistaAAtualizar == null) return Results.NotFound();
            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Pessoa não está conectada");
            var pessoaAvaliadora = await pessoaDAL.FindByEmailAsync(email) ?? throw new InvalidOperationException("Pessoa não encontrada");
            var avaliacaoExistente = artistaAAtualizar.Avaliacoes.FirstOrDefault(a => a.PessoaId == pessoaAvaliadora.Id && a.ArtistaId == avaliacaoRequest.ArtistaId);

            if (avaliacaoExistente is null)
            {
                artistaAAtualizar.AtribuirNota(pessoaAvaliadora.Id, avaliacaoRequest.Nota);
            }
            else
            {
                avaliacaoExistente.Nota = avaliacaoRequest.Nota;
            }

            artistaDAL.Atualizar(artistaAAtualizar);
            return Results.Created();
        });

        groupBuilder.MapPost("{id}/avaliacao", async (HttpContext context,
            [FromServices] DAL<Artista> artistaDAL,
            [FromServices] UserManager<PessoaComAcesso> pessoaDAL,
            [FromQuery] int id) =>
        {
            var artistaAAtualizar = artistaDAL.RecuperarArtistaComAvaliacoes(id);
            if (artistaAAtualizar == null) return Results.NotFound();
            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Pessoa não está conectada");
            var pessoaAvaliadora = await pessoaDAL.FindByEmailAsync(email) ?? throw new InvalidOperationException("Pessoa não encontrada");
            var avaliacaoExistente = artistaAAtualizar.Avaliacoes.FirstOrDefault(a => a.PessoaId == pessoaAvaliadora.Id && a.ArtistaId == id);

            var response = new AvaliacaoArtistaResponse(id, avaliacaoExistente?.Nota ?? 0);
            return Results.Ok(response);
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Artista> dal, int id) =>
        {
            var artistaADeletar = dal.RecuperarPor(a => a.Id == id);
            if (artistaADeletar == null) return Results.NotFound();

            dal.Deletar(artistaADeletar);

            return Results.NoContent();
        });
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