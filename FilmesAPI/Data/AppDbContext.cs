using FilmesAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data.DTOs
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base (opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Models.Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Models.Cinema>(cinema => cinema.EnderecoId);

            builder.Entity<Models.Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Models.Cinema> Cinemas { get; set; }
        public DbSet<Models.Endereco> Enderecos { get; set; }
        public DbSet<Models.Gerente> Gerentes { get; set; }

    }
}
