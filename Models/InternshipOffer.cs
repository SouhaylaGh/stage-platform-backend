using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageConnect.Models
{
    public class InternshipOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Domain { get; set; } = string.Empty;

        public string Level { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        public string Mode { get; set; } = "Présentiel";
        public string Address { get; set; } = string.Empty;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }

        public string Profile { get; set; } = string.Empty;
        public string Competences { get; set; } = string.Empty;
        public string Languages { get; set; } = string.Empty;

        public string Salary { get; set; } = string.Empty;
        public int Positions { get; set; } = 1;
        public string Benefits { get; set; } = string.Empty;

        public bool Urgent { get; set; }
        public bool Remote { get; set; }
        public bool Housing { get; set; }

        public string ContactName { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;

        // Champ JSON (liste de compétences techniques)
        public string Skills { get; set; } = string.Empty;
    }
}

