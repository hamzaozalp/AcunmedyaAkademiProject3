using AcunmedyaAkademiProject3.Context;
using AcunmedyaAkademiProject3.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult AboutList()
        {
            var value=_context.Abouts.ToList();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateAbout() 
        {
            return View();
            
        }
        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return View();
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return View(value);    
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return View();

        }
    }

}

