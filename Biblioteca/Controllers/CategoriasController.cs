using Microsoft.AspNetCore.Mvc;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
	public class CategoriasController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoriasController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Categorias> objTiposList = _db.Categorias;
			return View(objTiposList);
		}
        //get SELECT
        public IActionResult Create()
        {
            return View();
        }
        //post INSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorias objCategoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categorias.Add(objCategoria);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCategoria);
        }
        //get SELECT
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id <= 0)
            {
                return NotFound();
            }
            var categoriaFromDb = _db.Categorias.Find(Id);
            return View(categoriaFromDb);
        }
        //post UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorias objCategoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categorias.Update(objCategoria);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCategoria);
        }
        //get SELECT
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id <= 0)
            {
                return NotFound();
            }
            var categoriaFromDb = _db.Categorias.Find(Id);
            return View(categoriaFromDb);
        }
        //post DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            if (Id == null || Id <= 0)
            {
                return NotFound();
            }
            var objCategoria = _db.Categorias.Find(Id);
            if (objCategoria == null)
            {
                return NotFound();
            }
            _db.Categorias.Remove(objCategoria);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}