﻿namespace ScreenSound.Api.Response;

public record MusicaResponse(int Id, string Nome, int? ArtistaId, string NomeArtista, int? AnoLancamento, ICollection<GeneroResponse>? Generos = null);
