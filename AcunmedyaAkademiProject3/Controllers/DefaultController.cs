using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaAkademiProject3.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
