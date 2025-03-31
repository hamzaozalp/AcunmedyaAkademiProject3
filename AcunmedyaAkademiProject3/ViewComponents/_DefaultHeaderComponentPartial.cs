using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaAkademiProject3.ViewComponents
{
    public class _DefaultHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
