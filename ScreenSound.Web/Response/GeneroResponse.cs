namespace ScreenSound.Web.Response;

public record GeneroResponse(int id, string Nome, string Descricao)
{
    public override string ToString()
    {
        return this.Nome;
    }
}
