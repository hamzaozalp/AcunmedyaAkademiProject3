using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Data;
using AcunmedyaAkademiProject3.Models;
using System.Security.Claims;

namespace AcunmedyaAkademiProject3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminProfileController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Login");
            }

            var profile = await _context.AdminProfiles.FirstOrDefaultAsync();
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminProfile model, IFormFile profileImage)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var profile = await _context.AdminProfiles.FindAsync(model.Id);
            if (profile == null)
            {
                return NotFound();
            }

            // Profil resmi yükleme
            if (profileImage != null && profileImage.Length > 0)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads", "profile");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Eski resmi sil
                if (!string.IsNullOrEmpty(profile.ProfileImage) && profile.ProfileImage != "default-profile.jpg")
                {
                    var oldImagePath = Path.Combine(uploadsFolder, profile.ProfileImage);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Yeni resmi kaydet
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await profileImage.CopyToAsync(fileStream);
                }

                profile.ProfileImage = uniqueFileName;
            }

            // Diğer bilgileri güncelle
            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;
            profile.Email = model.Email;
            profile.Phone = model.Phone;
            profile.About = model.About;
            profile.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Profil bilgileri başarıyla güncellendi.";

            return RedirectToAction(nameof(Index));
        }
    }
} 