using FilmesAPI.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public static class FilmePaginadoExtensions 
    {
        public static FilmePaginado ToFilmePaginado(this IQueryable<ReadFilmeDto> query, FilmesPaginacao paginacao) 
        {

            int totaItens = query.Count();
            int totalPaginas = (int)Math.Ceiling(totaItens / (double)paginacao.Tamanho);

            return new FilmePaginado
            {
                Total = totaItens,
                TotalPaginas = totalPaginas,
                NumeroPagina = paginacao.Pagina,
                TamanhoPagina = paginacao.Tamanho,
                Resultado = query.Skip(paginacao.Tamanho * (paginacao.Pagina - 1))
                .Take(paginacao.Tamanho).ToList(),
                Anterior = (paginacao.Pagina > 1) ? 
                $"filmes?tamanho={paginacao.Pagina-1}&pagina={paginacao.Tamanho}": "",
                Proximo = (paginacao.Pagina < totalPaginas) ?
                $"filmes?tamanho={paginacao.Pagina + 1}&pagina={paginacao.Tamanho}" : "",
            };
        }
    }
    public class FilmePaginado
    {
        public int Total { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int NumeroPagina { get; set; }
        public IList<ReadFilmeDto> Resultado { get; set; }
        public string Anterior { get; set; }
        public string Proximo { get; set; }
    }
    public class FilmesPaginacao
    {
        public int Pagina { get; set; } = 1;
        public int Tamanho { get; set; } = 25;
    }
}
