using AcunmedyaAkademiProject3.Context;
using AcunmedyaAkademiProject3.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaAkademiProject3.ViewComponents
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        private readonly ProjectContext _context;
        public _DefaultFeatureComponentPartial(ProjectContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Set<Feature>().ToList();
            return View(values);
        }
    }
}
