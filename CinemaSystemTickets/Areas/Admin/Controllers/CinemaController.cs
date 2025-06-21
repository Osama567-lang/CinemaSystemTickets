using Microsoft.AspNetCore.Mvc;
using CinemaSystemTickets.DataAccess;
using CinemaSystemTickets.Models;

namespace CinemaSystemTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinemaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Cinema
        public IActionResult Index()
        {
            var cinemas = _context.Cinemas.ToList();
            return View(cinemas);
        }

        // GET: Admin/Cinema/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Cinema/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                _context.Cinemas.Add(cinema);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        // GET: Admin/Cinema/Edit/5
        public IActionResult Edit(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema == null)
                return NotFound();

            return View(cinema);
        }

        // POST: Admin/Cinema/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cinema cinema)
        {
            if (id != cinema.CinemaId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Cinemas.Update(cinema);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        // GET: Admin/Cinema/Delete/5
        public IActionResult Delete(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema == null)
                return NotFound();

            return View(cinema);
        }

        // POST: Admin/Cinema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
