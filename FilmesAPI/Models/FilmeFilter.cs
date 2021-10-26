using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public static class LivroFiltroExtensions
    {
        public static IQueryable<Filme> AplicaFiltro(this IQueryable<Filme> query, FilmeFilter filtro)
        {
            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Titulo))
                {
                    query = query.Where(l => l.Titulo.Contains(filtro.Titulo));
                }
                if (!string.IsNullOrEmpty(filtro.Director))
                {
                    query = query.Where(l => l.Director.Contains(filtro.Director));
                }
                if (!string.IsNullOrEmpty(filtro.Genero))
                {
                    query = query.Where(l => l.Genero.Contains(filtro.Genero));
                }
                if (filtro.Duracao > 0)
                {
                    query = query.Where(l => l.Duracao == filtro.Duracao);
                }
                if (filtro.ClassificacaoEtaria > 0)
                {
                    query = query.Where(l => l.ClassificacaoEtaria == filtro.ClassificacaoEtaria);
                }
            }
            return query;
        }
    }
    public class FilmeFilter
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        public string Capa { get; set; }
    }
}
