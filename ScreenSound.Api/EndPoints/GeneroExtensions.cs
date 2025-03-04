using Microsoft.AspNetCore.Mvc;
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
            return Results.Ok((dal.Listar().Select(genero => new GeneroResponse(genero.Nome, genero.Descricao))));
        });
    }
}
