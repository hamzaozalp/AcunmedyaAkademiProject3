using Microsoft.AspNetCore.Mvc;
using AcunmedyaAkademiProject3.Models;

namespace AcunmedyaAkademiProject3.ViewComponents
{
    public class _DefaultContactViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new ContactModel();
            return View(model);
        }
    }
}