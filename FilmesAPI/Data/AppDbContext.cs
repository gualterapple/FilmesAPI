using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOs
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base (opt)
        {
        }

        DbSet<Filme> Filmes { get; set; }
        DbSet<Cinema> Cinemas { get; set; }
    }
}
