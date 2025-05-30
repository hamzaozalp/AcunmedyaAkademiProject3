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
            Sliders = Set<Slider>();
            Skills = Set<Skill>();
            Statistics = Set<Statistic>();
            References = Set<Reference>();
            SocialMedias = Set<SocialMedia>();
            Experiences = Set<Experience>();
            Educations = Set<Education>();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
       
    }
}