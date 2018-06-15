using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        [StringLength(100, ErrorMessage = "O título do filme não pode contem mais que 100 caracteres")]
        public string Titulo { get; set; }

        [Display(Name = "Assistido em")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? AssistidoEm { get; set; }

    }
}
