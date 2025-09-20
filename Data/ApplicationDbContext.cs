using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StageConnect.Models;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StageConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Ajoute d'autres DbSet si besoin (ex: Offres, Candidatures, ...)
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<InternshipOffer> InternshipOffers { get; set; }
        public DbSet<Profil> Profils { get; set; }




    }

}

