using Microsoft.AspNetCore.Mvc;
using ScreenSound.Dados.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
    var artistaADeletar= dal.RecuperarPor(a => a.Id == id);
    if (artistaADeletar == null)
    {
        return Results.NotFound();
    }

    dal.Deletar(artistaADeletar);

    return Results.NoContent();
});


// Musicas

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

app.Run();

public partial class Program { }