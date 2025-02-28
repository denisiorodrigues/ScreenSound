namespace ScreenSound.Api.Requests;

public record MusicaRequestEdit(int id, int ArtistaId, string nome, int anoLancamento): MusicaRequest(nome, ArtistaId, anoLancamento);
