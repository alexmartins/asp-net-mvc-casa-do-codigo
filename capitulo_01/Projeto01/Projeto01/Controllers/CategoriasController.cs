using Projeto01.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
            {
                new Categoria() { CategoriaId = 1, Nome = "Notebooks" },
                new Categoria() { CategoriaId = 2, Nome = "Monitores" },
                new Categoria() { CategoriaId = 3, Nome = "Impressoras" },
                new Categoria() { CategoriaId = 4, Nome = "Mouses" },
                new Categoria() { CategoriaId = 5, Nome = "Desktops" }
            };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias.OrderBy(c => c.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria, long id)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == id).First());
            categorias.Add(categoria);
            categoria.CategoriaId = id;
            return RedirectToAction("Index");
        }

        // GET: Details
        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // GET: Delete
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria, long id)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == id).First());
            return RedirectToAction("Index");
        }

    }
}