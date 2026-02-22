using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ScreenSound.Web;
using ScreenSound.Web.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddTransient<CookieHandler>();
builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<GeneroService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddHttpClient("ScreenSoundAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseApi:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).AddHttpMessageHandler<CookieHandler>();

await builder.Build().RunAsync();