using System.ComponentModel.DataAnnotations;
using WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Serie
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [StringLength(100, ErrorMessage = "O título do filme não pode contem mais que 100 caracteres")]
        public string Titulo { get; set; }

        [Display(Name = "Capa")]
        [StringLength(200, ErrorMessage = "A url da capa não pode conter mais de 200 caracteres")]
        public string UrlCapa { get; set; }

        [Display(Name = "Total de Episódios")]
        public int TotalEpisodios { get; set; }

        public StatusSerie Status { get; set; }
    }
}
