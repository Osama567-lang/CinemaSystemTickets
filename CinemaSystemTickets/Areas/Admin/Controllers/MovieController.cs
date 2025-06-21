using Microsoft.AspNetCore.Mvc;
using CinemaSystemTickets.DataAccess;
using CinemaSystemTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystemTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Category).Include(m => m.Cinema).ToList();
            return View(movies);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Cinemas = _context.Cinemas.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Cinemas = _context.Cinemas.ToList();
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Cinemas = _context.Cinemas.ToList();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            if (id != movie.MovieId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Cinemas = _context.Cinemas.ToList();
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Include(m => m.Category).Include(m => m.Cinema).FirstOrDefault(m => m.MovieId == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
