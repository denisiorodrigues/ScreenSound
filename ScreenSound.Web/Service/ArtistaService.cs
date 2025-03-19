using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Service;

public class ArtistaService
{
    private readonly HttpClient _httpClient;

    public ArtistaService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("ScreenSoundAPI");
    }

    public async Task<ICollection<ArtistaResponse>> GetArtistas()
    {
        return await _httpClient.GetFromJsonAsync<List<ArtistaResponse>>("Artistas");
    }

    public async Task CadastrarArtistaAsync(ArtistaRequest request)
    {
        await _httpClient.PostAsJsonAsync($"Artistas", request);
    }
}
