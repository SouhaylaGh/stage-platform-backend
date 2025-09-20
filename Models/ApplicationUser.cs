using Microsoft.AspNetCore.Identity;

namespace StageConnect.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Champs communs
        public string Role { get; set; } = string.Empty;

        // Champs pour étudiant
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public string? NiveauEtude { get; set; }
        public string? DomaineEtude { get; set; }
        public string? Ville { get; set; }

        // Champs pour entreprise
        public string? NomEntreprise { get; set; }
        public string? SecteurActivite { get; set; }
        public string? TailleEntreprise { get; set; }
        public string? DescriptionEntreprise { get; set; }
        public string? NomContact { get; set; }
        public string? EmailPro { get; set; }
        public string? SiteWeb { get; set; }
        public string? Adresse { get; set; }

   
    }
}

