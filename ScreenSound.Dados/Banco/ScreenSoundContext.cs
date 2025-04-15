using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Dados.Modelos;
using ScreenSound.Modelos;

namespace ScreenSound.Dados.Banco;
public class ScreenSoundContext: IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    // private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    private string connectionString = "Host=localhost;Username=app;Password=senha123;Database=ScreenSound";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (optionsBuilder.IsConfigured) return;

        // optionsBuilder
        //     .UseSqlServer(connectionString)
        //     .UseLazyLoadingProxies();

        optionsBuilder
            .UseNpgsql(connectionString)
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musica>()
            .HasMany(a => a.Generos)
            .WithMany(m => m.Musicas);

        base.OnModelCreating(modelBuilder);
    }
}
