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
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Director é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "O gênero n pode ser maior que {1} caracters")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração minima é de 1 e a máxima de 600")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        public virtual List<Cinema> Cinemas { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }


    }
}