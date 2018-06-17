using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Database;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class EpisodioController : Controller
    {
        private readonly ZeroToHeroContext _contexto;

        public EpisodioController(ZeroToHeroContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Episodio/Listar
        public ActionResult Listar(int serieId)
        {
            var episodios = _contexto.Episodios.Where(x => x.SerieId == serieId).ToList();
            var serie = _contexto.Series.FirstOrDefault(x => x.Id == serieId);

            ListarEpisodioViewModel viewModel = new ListarEpisodioViewModel();

            viewModel.SerieId = serieId;
            viewModel.SerieTitulo = serie.Titulo;
            viewModel.Episodios = episodios;

            return View(viewModel);
        }

        // GET: Episodio/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            var episodio = _contexto.Episodios.FirstOrDefault(x => x.Id == id);

            return View(episodio);
        }

        // GET: Episodio/Cadastrar
        public ActionResult Cadastrar(int serieId)
        {
            return View(new Episodio { SerieId = serieId });
        }

        // POST: Episodio/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Episodio episodio)
        {
            try
            {
                _contexto.Episodios.Add(episodio);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Listar), new { serieId = episodio.SerieId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Episodio/Editar/5
        public ActionResult Editar(int id)
        {
            var episodio = _contexto.Episodios.FirstOrDefault(x => x.Id == id);

            return View(episodio);
        }

        // POST: Episodio/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, Episodio episodio)
        {
            try
            {
                var EpisodioSalvo = _contexto.Episodios.FirstOrDefault(x => x.Id == id);

                EpisodioSalvo.Titulo = episodio.Titulo;
                EpisodioSalvo.AssistidoEm = episodio.AssistidoEm;

                _contexto.SaveChanges();

                return RedirectToAction(nameof(Listar), new { serieId = episodio.SerieId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Episodio/Excluir/5
        public ActionResult Excluir(int id)
        {
            var episodio = _contexto.Episodios.FirstOrDefault(x => x.Id == id);

            return View(episodio);
        }

        // POST: Episodio/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, Episodio episodio)
        {
            try
            {
                var episodioSalvo = _contexto.Episodios.FirstOrDefault(x => x.Id == id);

                _contexto.Set<Episodio>().Remove(episodioSalvo);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Listar), new { serieId = episodio.SerieId });
            }
            catch
            {
                return View();
            }
        }
    }
}