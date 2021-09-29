using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOs.Cinema
{
    public class UpdateCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        public Models.Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
