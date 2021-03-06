﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Database;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SerieController : Controller
    {
        private readonly ZeroToHeroContext _contexto;

        public SerieController(ZeroToHeroContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Serie/Listar
        public ActionResult Listar()
        {
            var series = _contexto.Series.ToList();

            return View(series);
        }

        // GET: Serie/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            //DetalheSerieViewModel viewModel = new DetalheSerieViewModel();

            var serie = new Serie();
            serie = _contexto.Series.FirstOrDefault(x => x.Id == id);

            return View(serie);
        }

        // GET: Serie/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Serie/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Serie serie)
        {
            try
            {
                _contexto.Series.Add(serie);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        // GET: Serie/Editar/5
        public ActionResult Editar(int id)
        {
            var serie = _contexto.Series.FirstOrDefault(x => x.Id == id);

            return View(serie);
        }

        // POST: Serie/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, Serie serie)
        {
            try
            {
                var serieSalva = _contexto.Series.FirstOrDefault(x => x.Id == id);

                serieSalva.Titulo = serie.Titulo;
                serieSalva.UrlCapa = serie.UrlCapa;
                serieSalva.Status = serie.Status;

                _contexto.SaveChanges();

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        // GET: Serie/Excluir/5
        public ActionResult Excluir(int id)
        {
            var serie = _contexto.Series.FirstOrDefault(x => x.Id == id);

            return View(serie);
        }

        // POST: Serie/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, Serie serie)
        {
            try
            {
                var serieSalva = _contexto.Series.FirstOrDefault(x => x.Id == id);

                _contexto.Set<Serie>().Remove(serieSalva);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }
    }
}