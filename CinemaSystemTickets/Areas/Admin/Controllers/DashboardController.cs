using Microsoft.AspNetCore.Mvc;
using CinemaSystemTickets.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CinemaSystemTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            ViewBag.MovieCount = _context.Movies.Count();
            ViewBag.ActorCount = _context.Actors.Count();
            ViewBag.CinemaCount = _context.Cinemas.Count();
            ViewBag.CategoryCount = _context.Categories.Count();

            ViewBag.ActorNames = _context.Actors.Select(a => a.FirstName + " " + a.LastName).ToList();
            ViewBag.MovieNames = _context.Movies.Select(m => m.MovieName).ToList();
            ViewBag.CinemaNames = _context.Cinemas.Select(c => c.Name).ToList();
            ViewBag.CategoryNames = _context.Categories.Select(c => c.CategoryName).ToList();

            ViewBag.MoviePerCategory = _context.Categories
                .Select(c => new {
                    Category = c.CategoryName,
                    Count = c.Movies.Count()
                }).ToList();

            ViewBag.MoviesPerYear = _context.Movies
                .GroupBy(m => m.StartDate.Year)
                .Select(g => new {
                    Year = g.Key,
                    Count = g.Count()
                }).OrderBy(y => y.Year).ToList();

            ViewBag.TopActors = _context.Actors
                .Select(a => new {
                    Name = a.FirstName + " " + a.LastName,
                    Count = a.ActorMovies.Count()
                })
                .OrderByDescending(a => a.Count)
                .Take(5)
                .ToList();

            var movies = _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .Include(m => m.ActorMovies).ThenInclude(am => am.Actor)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(_context.Movies.Count() / (double)pageSize);

            return View(movies);
        }
    }
}
