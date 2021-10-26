using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOs
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Director é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "O gênero n pode ser maior que {1} caracters")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração minima é de 1 e a máxima de 600")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        public string Capa { get; set; }
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.Capa))
                {
                    return null;
                }
            
                //return $"https://apiirecord.azurewebsites.net{this.Capa.Substring(1)}";
                return Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\capas", this.Capa.Substring(1));
                //return @"C:/Users/gualter.sebastiao/source/repos/FilmesAPI/FilmesAPI/Uploads/capas"+this.Capa.Substring(1);
            }
        }
        public DateTime HoraConsulta { get; set; }
    }
}
