using Microsoft.AspNetCore.Mvc;
using CinemaSystemTickets.DataAccess;
using CinemaSystemTickets.Models;

namespace CinemaSystemTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;
            var actors = _context.Actors
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalActors = _context.Actors.Count();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalActors / pageSize);

            return View(actors);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Actors.Add(actor);
                _context.SaveChanges();

                TempData["Message"] = "✅ Actor added successfully!";
                TempData["MessageType"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        public IActionResult Edit(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null)
                return NotFound();

            return View(actor);
        }

        [HttpPost]
        public IActionResult Edit(int id, Actor actor)
        {
            if (id != actor.ActorID)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Actors.Update(actor);
                _context.SaveChanges();

                TempData["Message"] = "✏️ Actor updated successfully!";
                TempData["MessageType"] = "info";
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        public IActionResult Delete(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null)
                return NotFound();

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
                _context.SaveChanges();

                TempData["Message"] = "🗑️ Actor deleted successfully!";
                TempData["MessageType"] = "danger";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
