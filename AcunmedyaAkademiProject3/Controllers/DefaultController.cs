using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Context;
using System.Linq;
using AcunmedyaAkademiProject3.Models;

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

        [HttpPost]
        public IActionResult SendContactForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: İletişim formundan gelen veriyi işle (örn: e-posta gönder veya veritabanına kaydet)
                // Şimdilik sadece console'a yazdıralım veya loglayalım
                Console.WriteLine($"Yeni mesaj: Ad: {model.Name}, Email: {model.Email}, Konu: {model.Subject}, Mesaj: {model.Message}");

                // Başarılı olursa TempData'ya mesaj ekle ve Index sayfasına yönlendir
                TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi!";
                return RedirectToAction("Index", new { fragment = "contact" });
            }
            else
            {
                // Doğrulama hatası olursa Index sayfasına yönlendir
                // Hataları göstermek için Index View'ında ek düzenlemeler gerekebilir.
                // Şimdilik sadece yönlendirme yapıyoruz.
                return RedirectToAction("Index", new { fragment = "contact" });
            }
        }
    }
}