using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Context;
using AcunmedyaAkademiProject3.Entities;
using System.Threading.Tasks;

namespace AcunmedyaAkademiProject3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class YeteneklerimController : Controller
    {
        private readonly ProjectContext _context;

        public YeteneklerimController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Yeteneklerim
        public async Task<IActionResult> Index()
        {
            var skills = await _context.Skills.ToListAsync();
            return View(skills);
        }

        // GET: Admin/Yeteneklerim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Yeteneklerim/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillId,Name,Value,Duration")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Admin/Yeteneklerim/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: Admin/Yeteneklerim/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillId,Name,Value,Duration")] Skill skill)
        {
            if (id != skill.SkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.SkillId))
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
            return View(skill);
        }

        // POST: Admin/Yeteneklerim/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return _context.Skills.Any(e => e.SkillId == id);
        }
    }
} 