using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using FilmesAPI.Data.DTOs;

namespace FilmesAPI.Models
{
    public static class LivroOrdemExtensions 
    {
        public static IQueryable<ReadFilmeDto> AplicarOrdem(this IQueryable<ReadFilmeDto> query, FilmeOrdem ordem) 
        {
            if(!string.IsNullOrEmpty(ordem.OrdenarPor))
            {
                query = query.OrderBy(ordem.OrdenarPor);
            }
            return query;
        }
    }
    public class FilmeOrdem
    {
        public string OrdenarPor { get; set; }
    }
}
