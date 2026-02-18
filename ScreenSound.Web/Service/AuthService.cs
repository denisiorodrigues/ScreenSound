using System.Net.Http.Json;
using ScreenSound.Web.Response;

namespace ScreenSound.Web.Service;

public class AuthService(IHttpClientFactory factory)
{
    private readonly HttpClient _client = factory.CreateClient("ScreenSoundAPI");

    public async Task<AuthResponse> LoginAsync(string email, string password)
    {
        var response = await _client.PostAsJsonAsync("auth/login", new {email, password});

        if (response.IsSuccessStatusCode)
        {
            return new AuthResponse(){ Sucesso = true};
        }
        
        return new AuthResponse() { Sucesso = false, Erros = ["Usuário ou senha inválidos"]};
    }
}