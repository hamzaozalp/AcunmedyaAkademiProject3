using Microsoft.AspNetCore.Mvc;
using AcunmedyaAkademiProject3.Models;

namespace AcunmedyaAkademiProject3.ViewComponents
{
    [ViewComponent(Name = "ContactViewComponent")]
    public class ContactViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new ContactModel();
            return View(model);
        }
    }
}