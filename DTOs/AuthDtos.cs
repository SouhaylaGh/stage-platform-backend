using System.Text.Json.Serialization;

namespace StageConnect.DTOs
{
    public class SignupStudentDto
    {
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Ville { get; set; }
        public string? NiveauEtude { get; set; }
        public string? DomaineEtude { get; set; }
        public string? MotDePasse { get; set; }
        public string? ConfirmationMotDePasse { get; set; }
    }

    public class SignupEntrepriseDto
    {
        // Informations entreprise
        public string? NomEntreprise { get; set; }
        public string? SecteurActivite { get; set; }
        public string? TailleEntreprise { get; set; }
        public string? DescriptionEntreprise { get; set; }

        // Informations contact
        public string? NomContact { get; set; }
        public string? EmailPro { get; set; }
        public string? Telephone { get; set; }
        public string? SiteWeb { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }

        // Sécurité
        public string? MotDePasse { get; set; }
        public string? ConfirmationMotDePasse { get; set; }
    }

    // Pour les étudiants
    public class LoginStudentDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    // Pour les entreprises
    public class LoginCompanyDto
    {
        public string? EmailPro { get; set; }
        public string? Password { get; set; }
    }


    public class AuthResponseDto
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
        public string? UserId { get; set; }
        public string? Role { get; set; }
    }
}

