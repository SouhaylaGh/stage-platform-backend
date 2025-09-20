using System;
using System.ComponentModel.DataAnnotations;

namespace StageConnect.Models
{
    public class Profil
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Prenom { get; set; }

        [Required]
        public string? Nom { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Telephone { get; set; }

        public string? Ville { get; set; }

        public int Age { get; set; }

        public string? Biographie { get; set; }

        public string? NiveauEtudes { get; set; }

        public string? Domain { get; set; }

        public string? Ecole { get; set; }

        public string? AnneObtion { get; set; }

        public string? Competances { get; set; } // JSON string

        public string? CvPath { get; set; } // chemin du fichier PDF

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

