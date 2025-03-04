using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ScreenSound.Web;
using ScreenSound.Web.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ArtistaService>();

builder.Services.AddHttpClient("ScreenSoundAPI", client => {
    client.BaseAddress = new Uri(builder.Configuration["BaseApi:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
