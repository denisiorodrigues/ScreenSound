using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Service;

public class MusicaService
{
    private readonly HttpClient _httpClient;

    public MusicaService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("ScreenSoundAPI");
    }

    public async Task<ICollection<MusicaResponse>> GetMusicasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<MusicaResponse>>("Musicas");
    }

    public async Task CadastrarMusicaAsync(MusicaRequest request)
    {
        await _httpClient.PostAsJsonAsync($"Musicas", request);
    }
}
