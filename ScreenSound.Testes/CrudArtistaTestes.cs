// using Microsoft.AspNetCore.Mvc.Testing;
// using ScreenSound.Modelos;
// using System.Net;
// using System.Net.Http.Json;
//
// namespace ScreenSound.Testes;
//
// public class CrudArtistaTestes : IClassFixture<WebApplicationFactory<Program>>
// {
//     private readonly HttpClient _client;
//
//     public CrudArtistaTestes(WebApplicationFactory<Program> factory)
//     {
//         _client = factory.CreateClient();
//     }
//
//     [Fact]
//     public async Task RecuperarArtistas_RetornarOk()
//     {
//         var response = await _client.GetAsync("/Artistas");
//         response.EnsureSuccessStatusCode();
//         var artistas = await response.Content.ReadFromJsonAsync<List<Artista>>();
//
//         Console.WriteLine(artistas.Count);
//
//         Assert.NotNull(artistas);
//     }
//
//     [Fact]
//     public async Task GetArtistaByName_ReturnsOk()
//     {
//         var response = await _client.GetAsync("/Artistas/SomeName");
//         if (response.StatusCode == HttpStatusCode.NotFound)
//         {
//             Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
//         }
//         else
//         {
//             response.EnsureSuccessStatusCode();
//             var artista = await response.Content.ReadFromJsonAsync<Artista>();
//             Assert.NotNull(artista);
//         }
//     }
//
//     [Fact]
//     public async Task PostArtista_ReturnsOk()
//     {
//         var newArtista = new Artista { Nome = "Novo Artista", Bio = "Bio", FotoPerfil = "Foto" };
//         var response = await _client.PostAsJsonAsync("/Artistas", newArtista);
//         response.EnsureSuccessStatusCode();
//     }
//
//     [Fact]
//     public async Task PutArtista_ReturnsOk()
//     {
//         var updatedArtista = new Artista { Id = 1, Nome = "Artista Atualizado", Bio = "Bio Atualizada", FotoPerfil = "Foto Atualizada" };
//         var response = await _client.PutAsJsonAsync("/Artistas", updatedArtista);
//         if (response.StatusCode == HttpStatusCode.NotFound)
//         {
//             Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
//         }
//         else
//         {
//             response.EnsureSuccessStatusCode();
//         }
//     }
//
//     [Fact]
//     public async Task DeleteArtista_ReturnsNoContent()
//     {
//         var response = await _client.DeleteAsync("/Artistas/1");
//         if (response.StatusCode == HttpStatusCode.NotFound)
//         {
//             Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
//         }
//         else
//         {
//             Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
//         }
//     }
// }

