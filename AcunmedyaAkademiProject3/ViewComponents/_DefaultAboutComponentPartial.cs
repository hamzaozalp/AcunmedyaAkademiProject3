using AcunmedyaAkademiProject3.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaAkademiProject3.ViewComponents
{
    public class _DefaultAboutComponentPartial:ViewComponent
    {
        private readonly ProjectContext _context;

        public _DefaultAboutComponentPartial(ProjectContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }
    }
}
