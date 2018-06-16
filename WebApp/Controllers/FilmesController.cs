using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Database;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ZeroToHeroContext _contexto;

        public FilmesController(ZeroToHeroContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Filmes
        public ActionResult Listar()
        {
            var listagem = _contexto.Filmes.ToList();
            return View(listagem);
        }

        // GET: Filmes/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            var filme = _contexto.Filmes.FirstOrDefault(filmeC => filmeC.Id == id);
            return View(filme);
        }

        // GET: Filmes/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Filmes/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Filme filme)
        {
            try
            {
                _contexto.Add(filme);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        // GET: Filmes/Editar/5
        public ActionResult Editar(int id)
        {
            var filme = _contexto.Filmes.FirstOrDefault(filmeC => filmeC.Id == id);

            return View(filme);
        }

        // POST: Filmes/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, Filme filme)
        {
            try
            {
                var filmeSalvo = _contexto.Filmes.FirstOrDefault(filmeC => filmeC.Id == id);

                filmeSalvo.Titulo = filme.Titulo;
                filmeSalvo.AssistidoEm = filme.AssistidoEm;
                filmeSalvo.UrlCapa = filme.UrlCapa;

                _contexto.SaveChanges();

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        // GET: Filmes/Excluir/5
        public ActionResult Excluir(int id)
        {
            var filme = _contexto.Filmes.FirstOrDefault(filmeC => filmeC.Id == id);

            _contexto.SaveChanges();

            return View(filme);
        }

        // POST: Filmes/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, Filme filme)
        {
            try
            {
                _contexto.Set<Filme>().Remove(filme);
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