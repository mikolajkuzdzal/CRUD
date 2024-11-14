using Film3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Film3.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "opis1", Price=4},
            new Film(){Id = 2, Name = "Film2", Description = "opis2", Price=5},
            new Film(){Id = 3, Name = "Film3", Description = "opis3", Price=3},
        };

        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count > 0 ? films.Max(f => f.Id) + 1 : 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film updatedFilm)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            // Aktualizujemy dane filmu
            film.Name = updatedFilm.Name;
            film.Description = updatedFilm.Description;
            film.Price = updatedFilm.Price;

            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: FilmController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            // Usuwamy film z listy
            films.Remove(film);

            return RedirectToAction(nameof(Index));
        }
    }
}
