using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Context;
using AcunmedyaAkademiProject3.Entities;

namespace AcunmedyaAkademiProject3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly ProjectContext _context;

        public AboutController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var abouts = _context.Abouts.ToList();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                _context.Abouts.Add(about);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                _context.Update(about);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about != null)
            {
                _context.Abouts.Remove(about);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}