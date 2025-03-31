using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaAkademiProject3.ViewComponents
{
    public class _DefaultScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
