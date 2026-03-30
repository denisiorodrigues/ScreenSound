using Microsoft.AspNetCore.Components.Authorization;
using ScreenSound.Web.Response;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;

namespace ScreenSound.Web.Service;

public class AuthService(IHttpClientFactory factory) : AuthenticationStateProvider
{
    private readonly HttpClient _client = factory.CreateClient("ScreenSoundAPI");

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var pessoa = new ClaimsPrincipal();
        var infoResponse = await _client.GetAsync("auth/manage/info");

        if (infoResponse.IsSuccessStatusCode)
        {
            var info = await infoResponse.Content.ReadFromJsonAsync<InfoPessoaResponse>();
            
            Claim[] dados =
           [
               new Claim(ClaimTypes.Name, info.Email),
               new Claim(ClaimTypes.Email, info.Email)
           ];
           var identity = new ClaimsIdentity(dados, "Cookies");
           pessoa = new ClaimsPrincipal(identity);
        }

        return new AuthenticationState(pessoa);
    }

    public async Task<AuthResponse> LoginAsync(string email, string password)
    {
        var response = await _client.PostAsJsonAsync("auth/login?useCookies=true", new {email, password});

        if (response.IsSuccessStatusCode)
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return new AuthResponse(){ Sucesso = true};
        }
        
        return new AuthResponse() { Sucesso = false, Erros = ["Usuário ou senha inválidos"]};
    }
}