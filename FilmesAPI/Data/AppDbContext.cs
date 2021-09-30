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

            builder.Entity<Models.Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            builder.Entity<Models.Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Models.Cinema> Cinemas { get; set; }
        public DbSet<Models.Endereco> Enderecos { get; set; }
        public DbSet<Models.Gerente> Gerentes { get; set; }
        public DbSet<Models.Sessao> Sessoes { get; set; }

    }
}
