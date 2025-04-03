﻿using ScreenSound.Web.Requests;

namespace ScreenSound.Web.Response;

public record MusicaResponse(int Id, string Nome, int? ArtistaId, string NomeArtista, int AnoLancamento, ICollection<GeneroResponse> Generos = null);
