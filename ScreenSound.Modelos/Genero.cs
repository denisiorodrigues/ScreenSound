using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Modelos;

public class Genero
{
    [Key] public int Id { get; set; }

    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    public virtual ICollection<Musica> Musicas { get; set; }

    public override string ToString()
    {
        return $"Nome: {Nome} - Descricao: {Descricao}";
    }
}