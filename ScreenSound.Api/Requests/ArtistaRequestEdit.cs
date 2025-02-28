using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Api.Requests;

public record ArtistaRequestEdit([Required]int id, string nome, string bio)
    : ArtistaRequest(nome, bio);
