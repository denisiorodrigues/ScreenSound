using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Dados.Modelos;
using ScreenSound.Modelos;

namespace ScreenSound.Dados.Banco;

public class ScreenSoundContext: DbContext
{
    public ScreenSoundContext(DbContextOptions<ScreenSoundContext> options) : base(options)
    {
    }
    
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Musica>()
            .HasMany(a => a.Generos)
            .WithMany(m => m.Musicas);
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         var connectionString = "Server=localhost;Port=3306;Database=locadora;User=root;Password=senha123;";
    //         
    //         optionsBuilder.UseMySql(
    //             connectionString,
    //             ServerVersion.AutoDetect(connectionString) // Versão automática
    //         );
    //     }
    // }
}
