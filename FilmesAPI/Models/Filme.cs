using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get;  set; }
        [Required(ErrorMessage = "O campo Titulo ? obrigat?rio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Director ? obrigat?rio")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "O g?nero n pode ser maior que {1} caracters")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A dura??o minima ? de 1 e a m?xima de 600")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        public string Capa { get; set; }
        public virtual List<Cinema> Cinemas { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }


    }
}