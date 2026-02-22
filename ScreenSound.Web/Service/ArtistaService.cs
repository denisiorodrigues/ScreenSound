using System.Net.Http.Json;
using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;

namespace ScreenSound.Web.Service;

public class ArtistaService
{
    private readonly HttpClient _httpClient;

    public ArtistaService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("ScreenSoundAPI");
    }

    public async Task<ICollection<ArtistaResponse>> GetArtistaAsyncs()
    {
        return await _httpClient.GetFromJsonAsync<List<ArtistaResponse>>("artistas");
    }

    public async Task CadastrarArtistaAsync(ArtistaRequest request)
    {
        await _httpClient.PostAsJsonAsync("artistas", request);
    }

    public async Task EditarArtistaAsync(ArtistaRequestEdit request)
    {
        var response = await _httpClient.PutAsJsonAsync("artistas", request);
        if (response == null || !response.IsSuccessStatusCode) throw new Exception("Erro ao editar artista");
    }

    public async Task DeletarArtistaAsync(int id)
    {
        await _httpClient.DeleteAsync($"artistas/{id}");
    }

    public async Task<ArtistaResponse> GetArtistaPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{nome}");
    }
}