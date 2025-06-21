using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaSystemTickets.Models;
using CinemaSystemTickets.DataAccess;
using CinemaSystemTickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystemTickets.Areas.Customers.Controllers
{
    [Area("Customers")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(MovieWithFilterVM movie, int page = 1)
        {
            IQueryable<Movie> Movies = _context.Movies
               .Include(m => m.Category)
               .Include(m => m.Cinema);

            const double totalNumberOfMoviesPerPage = 9.0;

            ViewBag.Categories = _context.Categories.ToList();

            if (!string.IsNullOrEmpty(movie.MovieName))
            {
                Movies = Movies.Where(e => e.MovieName.Contains(movie.MovieName));
                ViewBag.movieName = movie.MovieName;
            }

            if (movie.CategoryId != null && movie.CategoryId > 0)
            {
                Movies = Movies.Where(e => e.CategoryID == movie.CategoryId);
                ViewBag.categoryId = movie.CategoryId;
            }

            if (movie.MovieStatus.HasValue)
            {
                Movies = Movies.Where(e =>
                    (DateTime.Now < e.StartDate && movie.MovieStatus == MovieStatus.Upcoming) ||
                    (DateTime.Now >= e.StartDate && DateTime.Now <= e.EndDate && movie.MovieStatus == MovieStatus.Available) ||
                    (DateTime.Now > e.EndDate && movie.MovieStatus == MovieStatus.Expired)
                );
                ViewBag.movieStatus = movie.MovieStatus;
            }

            int totalMoviesCount = Movies.Count();
            var totalNumberOfPages = Math.Ceiling(totalMoviesCount / totalNumberOfMoviesPerPage);

            // ✅ لو الصفحة أكبر من العدد المتاح نرجع لأول صفحة
            if (page > totalNumberOfPages && totalNumberOfPages > 0)
                page = 1;

            Movies = Movies.Skip((page - 1) * (int)totalNumberOfMoviesPerPage)
                           .Take((int)totalNumberOfMoviesPerPage);

            ViewBag.totalNumberOfPages = totalNumberOfPages;
            ViewBag.currentPage = page;
            ViewBag.FilteredMovies = _context.Movies.ToList(); // علشان الدروب داون

            return View(Movies.ToList());
        }

        public IActionResult ShowDetails(int movieID)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .Include(m => m.ActorMovies).ThenInclude(am => am.Actor)
                .FirstOrDefault(m => m.MovieId == movieID);

            if (movie == null)
                return RedirectToAction("Index");

            var actors = movie.ActorMovies
                .Where(am => am.Actor != null)
                .Select(am => am.Actor)
                .ToList();

            return View(new MovieWithRelatedVM
            {
                Movie = movie,
                Actors = actors
            });
        }
        public IActionResult ActorDetails(int id)
        {
            var actor = _context.Actors
                .Include(a => a.ActorMovies)
                .ThenInclude(am => am.Movie)
                .FirstOrDefault(a => a.ActorID == id);

            if (actor == null)
                return NotFound();

            return View(actor);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
