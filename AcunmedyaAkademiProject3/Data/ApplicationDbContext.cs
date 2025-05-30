using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Models;

namespace AcunmedyaAkademiProject3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminProfile> AdminProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Varsayılan admin kullanıcısını ekle
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("password"), // Şifreyi hashle
                    CreatedAt = DateTime.Now,
                    IsActive = true
                }
            );

            // Varsayılan admin profilini ekle
            modelBuilder.Entity<AdminProfile>().HasData(
                new AdminProfile
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    Phone = "",
                    ProfileImage = "default-profile.jpg",
                    About = "Admin kullanıcısı",
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
} 