using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Context;
using AcunmedyaAkademiProject3.Entities;
using System.Threading.Tasks;

namespace AcunmedyaAkademiProject3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IstatistiklerController : Controller
    {
        private readonly ProjectContext _context;

        public IstatistiklerController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Istatistikler
        public async Task<IActionResult> Index()
        {
            var statistics = await _context.Statistics.ToListAsync();
            return View(statistics);
        }

        // GET: Admin/Istatistikler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Istatistikler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatisticId,Title,Value")] Statistic statistic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statistic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statistic);
        }

        // GET: Admin/Istatistikler/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var statistic = await _context.Statistics.FindAsync(id);
            if (statistic == null)
            {
                return NotFound();
            }
            return View(statistic);
        }

        // POST: Admin/Istatistikler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatisticId,Title,Value")] Statistic statistic)
        {
            if (id != statistic.StatisticId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statistic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatisticExists(statistic.StatisticId))
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
            return View(statistic);
        }

        // POST: Admin/Istatistikler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var statistic = await _context.Statistics.FindAsync(id);
            if (statistic != null)
            {
                _context.Statistics.Remove(statistic);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StatisticExists(int id)
        {
            return _context.Statistics.Any(e => e.StatisticId == id);
        }
    }
} 