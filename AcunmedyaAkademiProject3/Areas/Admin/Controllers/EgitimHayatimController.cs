using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Context;
using AcunmedyaAkademiProject3.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace AcunmedyaAkademiProject3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EgitimHayatimController : Controller
    {
        private readonly ProjectContext _context;

        public EgitimHayatimController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/EgitimHayatim
        public async Task<IActionResult> Index()
        {
            var education = await _context.Educations.ToListAsync();
            return View(education);
        }

        // GET: Admin/EgitimHayatim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/EgitimHayatim/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EducationId,SchoolName,Department,StartDate,EndDate")] Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(education);
        }

        // GET: Admin/EgitimHayatim/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            return View(education);
        }

        // POST: Admin/EgitimHayatim/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EducationId,SchoolName,Department,StartDate,EndDate")] Education education)
        {
            if (id != education.EducationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.EducationId))
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
            return View(education);
        }

        // POST: Admin/EgitimHayatim/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.EducationId == id);
        }
    }
} 