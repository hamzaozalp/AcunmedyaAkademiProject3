using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Context;
using AcunmedyaAkademiProject3.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace AcunmedyaAkademiProject3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SosyalMedyaController : Controller
    {
        private readonly ProjectContext _context;

        public SosyalMedyaController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/SosyalMedya
        public async Task<IActionResult> Index()
        {
            var socialMedias = await _context.SocialMedias.ToListAsync();
            return View(socialMedias);
        }

        // GET: Admin/SosyalMedya/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SosyalMedya/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SocialMediaId,Icon,Url,Username")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialMedia);
        }

        // GET: Admin/SosyalMedya/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }
            return View(socialMedia);
        }

        // POST: Admin/SosyalMedya/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SocialMediaId,Icon,Url,Username")] SocialMedia socialMedia)
        {
            if (id != socialMedia.SocialMediaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaExists(socialMedia.SocialMediaId))
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
            return View(socialMedia);
        }

        // POST: Admin/SosyalMedya/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia != null)
            {
                _context.SocialMedias.Remove(socialMedia);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediaExists(int id)
        {
            return _context.SocialMedias.Any(e => e.SocialMediaId == id);
        }
    }
} 