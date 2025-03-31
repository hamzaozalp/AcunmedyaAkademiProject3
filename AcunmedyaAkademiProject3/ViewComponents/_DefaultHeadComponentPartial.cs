using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaAkademiProject3.ViewComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
