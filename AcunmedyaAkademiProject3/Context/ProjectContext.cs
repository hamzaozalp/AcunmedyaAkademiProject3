using AcunmedyaAkademiProject3.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AcunmedyaAkademiProject3.Context
{
    public class ProjectContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HAMZA;initial catalog=AcunmedyaDb3;integrated security=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Product> Products { get; set; } 
    }
}
//trustservercertificate=true;
    