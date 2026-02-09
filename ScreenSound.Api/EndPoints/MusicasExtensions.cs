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
        app.MapGet("/Musicas",
            ([FromServices] DAL<Musica> dal) => { return Results.Ok(EntityListToResponseList(dal.Listar())); });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarMusicaPorNomeComGeneros(nome);
            if (musica == null) return Results.NotFound();

            return Results.Ok(EntityToResponse(musica));
        });

        app.MapGet("/Musicas/Artista/{artistaId}", ([FromServices] DAL<Musica> dal, int artistaId) =>
        {
            var musicas = dal.ListarPor(a => a.Artista.Id == artistaId);
            if (musicas == null) return Results.NotFound();

            return Results.Ok(musicas);
        });

        app.MapPost("/Musicas",
            ([FromServices] DAL<Musica> musicaDAL, [FromServices] DAL<Genero> generoDAL,
                [FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.nome, musicaRequest.anoLancamento);
                musica.ArtistaId = musicaRequest.ArtistaId;
                musica.Generos = GeneroRequestConverter(generoDAL, musicaRequest.Generos);
                musicaDAL.Adicionar(musica);

                return Results.Ok();
            });

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> musicaDAL, [FromServices] DAL<Genero> generoDAL,
            [FromBody] MusicaRequestEdit musicaRequest
        ) =>
        {
            var musicaAAtualizar = musicaDAL.RecuperarPor(a => a.Id == musicaRequest.id);
            if (musicaAAtualizar == null) return Results.NotFound();

            musicaAAtualizar.Nome = musicaRequest.nome;
            musicaAAtualizar.AnoLancamento = musicaRequest.anoLancamento;
            musicaAAtualizar.ArtistaId = musicaRequest.ArtistaId;
            musicaAAtualizar.Generos = GeneroRequestConverter(generoDAL, musicaRequest.Generos);

            musicaDAL.Atualizar(musicaAAtualizar);

            return Results.Ok();
        });

        app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
        {
            var musicaADeletar = dal.RecuperarPor(a => a.Id == id);
            if (musicaADeletar == null) return Results.NotFound();

            dal.Deletar(musicaADeletar);

            return Results.NoContent();
        });
    }

    private static ICollection<Genero> GeneroRequestConverter(DAL<Genero> generoDAL, ICollection<GeneroRequest> generos)
    {
        if (generos is null) return new List<Genero>();
        var generoRelacionado = new List<Genero>();

        foreach (var generoResponse in generos)
        {
            var genero = GeneroRequestToEntity(generoResponse);
            var generoEncontrado = generoDAL.RecuperarPor(a => a.Nome.ToLower().Equals(genero.Nome.ToLower()));
            if (generoEncontrado is null)
                generoRelacionado.Add(genero);
            else
                generoRelacionado.Add(generoEncontrado);
        }

        return generoRelacionado;
    }

    private static Genero GeneroRequestToEntity(GeneroRequest generoRequest)
    {
        return new Genero { Nome = generoRequest.Nome, Descricao = generoRequest.Descricao };
    }

    private static ICollection<GeneroResponse> GenerosToGenerosResponseEdit(ICollection<Genero> generos)
    {
        return generos.Select(s => new GeneroResponse(s.Id, s.Nome, s.Descricao)).ToList();
    }

    private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
    {
        return musicaList.Select(a => EntityToResponse(a)).ToList();
    }

    private static MusicaResponse EntityToResponse(Musica musica)
    {
        var generosResponse = GenerosToGenerosResponseEdit(musica.Generos);
        return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista?.Id, musica.Artista?.Nome,
            musica.AnoLancamento, generosResponse);
    }
}