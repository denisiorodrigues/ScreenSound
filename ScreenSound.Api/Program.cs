using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Api.EndPoints;
using ScreenSound.Dados.Banco;
using ScreenSound.Dados.Modelos;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var connectionString = builder.Configuration.GetConnectionString("ScreenSoundDB");

builder.Services.AddDbContext<ScreenSoundContext>(options =>
{
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 44)));
});

builder.Services
    .AddIdentityApiEndpoints<PessoaComAcesso>()
    .AddEntityFrameworkStores<ScreenSoundContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Obrigatório para HTTPS
    options.Cookie.SameSite = SameSiteMode.None; // "None" permite cross-site entre portas diferentes
    options.Cookie.Name = ".AspNetCore.Identity.Application"; // Nome padrão do cookie
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
    options.LoginPath = "/auth/login";
    options.LogoutPath = "/auth/logout";
    options.AccessDeniedPath = "/";
});

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "http://localhost:5278",
                builder.Configuration["FrontendUrl"] ?? "http://localhost:5278"])
            .AllowAnyMethod()
            .SetIsOriginAllowed(pol => true)
            .AllowAnyHeader()
            .AllowCredentials()));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddTransient<DAL<Genero>>();

var app = builder.Build();

app.UseCors("wasm");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();
app.AddEndPointsGeneros();

app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Autorização");

app.MapPost("auth/logout", async ([Microsoft.AspNetCore.Mvc.FromServices] SignInManager<PessoaComAcesso> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Autorização");

app.Run();