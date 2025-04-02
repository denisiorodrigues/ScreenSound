﻿namespace ScreenSound.Api.Requests;

public record MusicaRequestEdit(int id, int ArtistaId, string nome, int anoLancamento, ICollection<GeneroRequest> Generos = null) : MusicaRequest(nome, ArtistaId, anoLancamento);
