using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class ListarEpisodioViewModel
    {
        public ListarEpisodioViewModel()
        {
            Episodios = new List<Episodio>();
        }

        public string SerieTitulo { get; set; }
        public int SerieId { get; set; }
        public List<Episodio> Episodios { get; set; }
    }
}
