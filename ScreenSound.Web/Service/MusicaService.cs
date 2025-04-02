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

    public async Task<MusicaResponse> GetMusicaPorNomeAsync(string nomeDaMusica)
    {
        return await _httpClient.GetFromJsonAsync<MusicaResponse>($"Musicas/{nomeDaMusica}");
    }

    public async Task CadastrarMusicaAsync(MusicaRequest request)
    {
        await _httpClient.PostAsJsonAsync($"Musicas", request);
    }

    public async Task AtualizarMusicaAsync(MusicaRequestEdit musicaRequestEdit)
    {
        await _httpClient.PutAsJsonAsync("Musicas", musicaRequestEdit);
    }

    public async Task DeletarMusicaAsync(int musicaId)
    {
        await _httpClient.DeleteAsync($"Musicas/{musicaId}");
    }
}
