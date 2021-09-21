using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get;  set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Director é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "O gênero n pode ser maior que {1} caracters")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração minima é de 1 e a máxima de 600")]
        public int Duracao { get; set; }
    }
}