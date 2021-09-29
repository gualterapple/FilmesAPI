using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
      
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        [JsonIgnore]
        public virtual Gerente Gerente { get; set; }
        [JsonIgnore]
        public virtual int GerenteId { get; set; }
    }
}
