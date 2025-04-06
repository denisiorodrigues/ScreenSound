using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Web.Requests;

public record ArtistaRequestEdit([Required]int id, string nome, string bio, string? fotoPerfil);

