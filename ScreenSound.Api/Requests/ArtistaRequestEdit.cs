using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Api.Requests;

public record ArtistaRequestEdit([Required] int id, string nome, string bio, string? fotoPefil)
    : ArtistaRequest(nome, bio, fotoPefil);