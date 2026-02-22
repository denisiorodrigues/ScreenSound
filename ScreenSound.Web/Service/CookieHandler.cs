using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace ScreenSound.Web.Service;

public class CookieHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
         
        // Log para debug
        Console.WriteLine($"Enviando requisição para: {request.RequestUri}");
        Console.WriteLine($"Headers: {string.Join(", ", request.Headers.Select(h => $"{h.Key}: {string.Join(",", h.Value)}"))}");
        
        request.Headers.Add("Cache-Control", "no-cache, no-store");
        
        var response = await base.SendAsync(request, cancellationToken);
        
        Console.WriteLine($"Resposta: {response.StatusCode}");
        return response; 
    }
}