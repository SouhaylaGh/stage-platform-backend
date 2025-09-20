using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StageConnect.DTOs
{
    public class ProfilDto
    {
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
        public List<string> Competances { get; set; }
        public IFormFile CvFile { get; set; } // fichier PDF
    }
}

