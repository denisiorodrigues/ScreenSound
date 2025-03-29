﻿using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Service;

public class GeneroService
{
    private readonly HttpClient _httpClient;

    public GeneroService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<List<GeneroResponse>?> GetGenerosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<GeneroResponse>>("Generos");
    } 
    public async Task<GeneroResponse?> GetGeneroPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<GeneroResponse>($"Generos/{nome}");
    }
}
