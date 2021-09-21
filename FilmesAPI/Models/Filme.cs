using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get;  set; }
        [Required(ErrorMessage = "O campo Titulo � obrigat�rio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Director � obrigat�rio")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "O g�nero n pode ser maior que {1} caracters")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A dura��o minima � de 1 e a m�xima de 600")]
        public int Duracao { get; set; }
    }
}