using Microsoft.EntityFrameworkCore;
using AcunmedyaAkademiProject3.Entities;

namespace AcunmedyaAkademiProject3.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            Categories = Set<Category>();
            Abouts = Set<About>();
            Products = Set<Product>();
            Contacts = Set<Contact>();
            Features = Set<Feature>();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}