using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class DetalheSerieViewModel
    {
        public Models.Serie Serie { get; set; }

        [Display(Name = "Num. de episódios")]
        public int NumeroEpisodios { get; set; }
    }
}
