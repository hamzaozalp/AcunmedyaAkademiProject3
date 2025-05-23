using AcunmedyaAkademiProject3.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaAkademiProject3.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public IActionResult Index()
        {
            return View();
        }

        // POST: Contact
        [HttpPost]
        public IActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                // Burada iletişim verilerini işleyebilirsiniz (örneğin kaydetmek veya göndermek)
                TempData["Success"] = "İletişiminiz alınmıştır. Teşekkür ederiz!";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
