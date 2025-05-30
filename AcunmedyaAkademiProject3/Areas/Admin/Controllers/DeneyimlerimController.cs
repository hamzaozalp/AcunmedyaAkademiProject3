using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Context;
using AcunmedyaAkademiProject3.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace AcunmedyaAkademiProject3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeneyimlerimController : Controller
    {
        private readonly ProjectContext _context;

        public DeneyimlerimController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Deneyimlerim
        public async Task<IActionResult> Index()
        {
            var experiences = await _context.Experiences.ToListAsync();
            return View(experiences);
        }

        // GET: Admin/Deneyimlerim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Deneyimlerim/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperienceId,Title,CompanyName,StartDate,EndDate,Description")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }

        // GET: Admin/Deneyimlerim/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }

        // POST: Admin/Deneyimlerim/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperienceId,Title,CompanyName,StartDate,EndDate,Description")] Experience experience)
        {
            if (id != experience.ExperienceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.ExperienceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }

        // POST: Admin/Deneyimlerim/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience != null)
            {
                _context.Experiences.Remove(experience);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experiences.Any(e => e.ExperienceId == id);
        }
    }
} 