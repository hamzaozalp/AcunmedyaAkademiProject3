using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AcunmedyaAkademiProject3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CikisYapController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // Kullanıcının kimlik doğrulama çerezini silerek oturumu kapat
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            // Giriş sayfasına veya ana sayfaya yönlendir
            return RedirectToAction("Index", "Login"); // Giriş controller'ınızın adına göre düzenlenmeli
        }
    }
} 