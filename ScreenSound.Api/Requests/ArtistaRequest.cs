using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Api.Requests;

public record ArtistaRequest([Required] string nome, [Required] string bio);
