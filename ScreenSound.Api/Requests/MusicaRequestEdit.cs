namespace ScreenSound.Api.Requests;

public record MusicaRequestEdit(int id, int ArtistaId, string nome, int anoLancamento, IList<GeneroRequest> Generos)
    : MusicaRequest(nome, ArtistaId, anoLancamento)
{
    public IList<GeneroRequest> Generos { get; init; } = Generos;
}