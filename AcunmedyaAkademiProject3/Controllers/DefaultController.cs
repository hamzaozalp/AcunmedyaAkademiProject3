using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Context;
using System.Linq;

namespace AcunmedyaAkademiProject3.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ProjectContext _context;

        public DefaultController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var features = _context.Features.ToList();
            var abouts = _context.Abouts.ToList();
            var products = _context.Products.ToList();
            var categories = _context.Categories.ToList();

            return View();
        }
    }
}