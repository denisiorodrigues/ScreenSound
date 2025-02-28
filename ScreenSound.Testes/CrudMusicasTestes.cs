using Microsoft.AspNetCore.Mvc.Testing;
using ScreenSound.Dados.Banco;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Testes;

public class CrudMusicasTestes : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CrudMusicasTestes(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public void AdicionarMusica()
    {
        // Arrange
        var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
        var artista = new Artista("Artista Teste", "Bio de teste");
        artistaDAL.Adicionar(artista);
        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var musica = new Musica("Musica Teste", 2022);
        // Act
        artista.AdicionarMusica(musica);
        artistaDAL.Atualizar(artista);
        // Assert
        var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals("Artista Teste"));
        Assert.NotNull(artistaRecuperado);
        Assert.Equal(1, artistaRecuperado.Musicas.Count);
        Assert.Equal("Musica Teste", artistaRecuperado.Musicas.First().Nome);
    }
    [Fact]
    public void AtualizarMusica()
    {
        // Arrange
        var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
        var artista = new Artista("Artista Teste", "Bio de teste");
        artistaDAL.Adicionar(artista);
        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var musica = new Musica("Musica Teste", 2022);
        artista.AdicionarMusica(musica);
        artistaDAL.Atualizar(artista);
        // Act
        var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals("Artista Teste"));
        var musicaRecuperada = artistaRecuperado.Musicas.First();
        musicaRecuperada.Nome = "Musica Atualizada";
        artistaDAL.Atualizar(artistaRecuperado);
        // Assert
        var artistaRecuperadoNovamente = artistaDAL.RecuperarPor(a => a.Nome.Equals("Artista Teste"));
        Assert.NotNull(artistaRecuperadoNovamente);
        Assert.Equal(1, artistaRecuperadoNovamente.Musicas.Count);
        Assert.Equal("Musica Atualizada", artistaRecuperadoNovamente.Musicas.First().Nome);
    }
    [Fact]
    public void DeletarMusica()
    {
        // Arrange
        var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
        var artista = new Artista("Artista Teste", "Bio de teste");
        artistaDAL.Adicionar(artista);
        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var musica = new Musica("Musica Teste", 2022);
        artista.AdicionarMusica(musica);
        artistaDAL.Atualizar(artista);
        // Act
        var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals("Artista Teste"));
        var musicaRecuperada = artistaRecuperado.Musicas.First();
        artista.Musicas.Remove(musicaRecuperada);
        musicaDAL.Deletar(musicaRecuperada);
        // Assert
        var artistaRecuperadoNovamente = artistaDAL.RecuperarPor(a => a.Nome.Equals("Artista Teste"));
        Assert.NotNull(artistaRecuperadoNovamente);
        Assert.Empty(artistaRecuperadoNovamente.Musicas);
    }
}
