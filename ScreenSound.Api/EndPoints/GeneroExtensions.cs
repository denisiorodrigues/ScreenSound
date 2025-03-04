using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Requests;
using ScreenSound.Api.Response;
using ScreenSound.Dados.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class GeneroExtensions
{
    public static void AddEndPointsGeneros(this WebApplication app)
    {
        app.MapGet("/Generos", ([FromServices] DAL<Genero> dal) =>
        {
            return Results.Ok(ConvertListGeneroToResponse(dal.Listar()));
        });

        app.MapGet("/Generos/{nome}", ([FromServices] DAL<Genero> dal, string nome) =>
        {
            var generoEncontrado = dal.RecuperarPor(g => g.Nome.ToUpper().Equals(nome.ToUpper()));
            
            if (generoEncontrado is null) return Results.NotFound();

            return Results.Ok(ConvertEntityToResponse(generoEncontrado));
        });

        app.MapPost("/Generos", ([FromServices] DAL<Genero> dal, GeneroRequest generoRequest) =>
        {
            var genero = new Genero() { Nome = generoRequest.Nome, Descricao = generoRequest.Descricao };
            dal.Adicionar(genero);
            return Results.Ok();
        });

        app.MapPut("/Generos", ([FromServices] DAL<Genero> dal, GeneroRequestEdit generoRequestEdit) =>
        {
            var generoEncontrado = dal.RecuperarPor(g => g.Nome.ToUpper().Equals(generoRequestEdit.Nome.ToUpper()));

            if(generoEncontrado is null)
                return Results.BadRequest("Genero não encontrado");

            generoEncontrado.Nome = generoRequestEdit.Nome;
            generoEncontrado.Descricao = generoRequestEdit.Descricao;
            dal.Atualizar(generoEncontrado);

            return Results.Ok();
        });

        app.MapDelete("/Generos", ([FromServices] DAL<Genero> dal, int id) =>
        {
            var generoEncontrado = dal.RecuperarPor(g => g.Id == id);

            if (generoEncontrado is null)
                return Results.BadRequest("Genero não encontrado");

            dal.Deletar(generoEncontrado);

            return Results.Ok();
        });
    }

    private static object? ConvertListGeneroToResponse(IEnumerable<Genero> enumerable)
    {
        return enumerable.Select(g => ConvertEntityToResponse(g));
    }

    private static GeneroResponse ConvertEntityToResponse(Genero g)
    {
        return new GeneroResponse(g.Nome, g.Descricao);
    }
}
