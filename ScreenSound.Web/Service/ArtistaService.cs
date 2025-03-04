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
}
