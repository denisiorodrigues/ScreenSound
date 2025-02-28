﻿namespace ScreenSound.Modelos;

public class Musica
{
    public Musica() { } //EF

    public Musica(string nome, int? anoLancamento)
    {
        Nome = nome;
        AnoLancamento = anoLancamento;
    }

    public string Nome { get; set; }
    public int Id { get; set; }

    public int? AnoLancamento { get; set; }

    public int? ArtistaId { get; set; }

    public virtual Artista? Artista { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome} - {AnoLancamento}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}