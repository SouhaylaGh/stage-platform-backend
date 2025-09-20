using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StageConnect.Data;
using StageConnect.DTOs;
using StageConnect.Models;

namespace StageConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProfilController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProfil([FromForm] ProfilDto dto)
        {
            try
            {
                string cvPath = null;

                // Vérifier si un fichier PDF est envoyé
                if (dto.CvFile != null && dto.CvFile.Length > 0)
                {
                    var uploadsDir = Path.Combine(_env.WebRootPath ?? "wwwroot", "Uploads", "CV");
                    if (!Directory.Exists(uploadsDir))
                        Directory.CreateDirectory(uploadsDir);

                    var fileName = $"{Guid.NewGuid()}_{dto.CvFile.FileName}";
                    cvPath = Path.Combine(uploadsDir, fileName);

                    using (var stream = new FileStream(cvPath, FileMode.Create))
                    {
                        await dto.CvFile.CopyToAsync(stream);
                    }
                }

                // Sauvegarder le profil dans la base de données
                var profil = new Profil
                {
                    Prenom = dto.Prenom,
                    Nom = dto.Nom,
                    Email = dto.Email,
                    Telephone = dto.Telephone,
                    Ville = dto.Ville,
                    Age = dto.Age,
                    Biographie = dto.Biographie,
                    NiveauEtudes = dto.NiveauEtudes,
                    Domain = dto.Domain,
                    Ecole = dto.Ecole,
                    AnneObtion = dto.AnneObtion,
                    Competances = dto.Competances != null ? string.Join(",", dto.Competances) : null,
                    CvPath = cvPath
                };

                _context.Add(profil);
                await _context.SaveChangesAsync();

                return Ok(new { message = "✅ Profil créé avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "❌ Erreur lors de la création du profil", details = ex.Message });
            }
        }
        [HttpGet("last")]
        public async Task<IActionResult> GetLastProfil()
        {
            var lastProfil = await _context.Profils
                .OrderByDescending(p => p.Id) // On prend le dernier profil créé
                .FirstOrDefaultAsync();

            if (lastProfil == null)
                return NotFound(new { message = "⚠️ Aucun profil trouvé" });

            return Ok(lastProfil);
        }

        // =========================
        // GET : Télécharger le CV du dernier profil
        // =========================
        [HttpGet("last/cv")]
        public async Task<IActionResult> DownloadLastCv()
        {
            var lastProfil = await _context.Profils
                .OrderByDescending(p => p.Id)
                .FirstOrDefaultAsync();

            if (lastProfil == null || string.IsNullOrEmpty(lastProfil.CvPath))
                return NotFound(new { message = "⚠️ CV introuvable" });

            var filePath = lastProfil.CvPath;

            if (!System.IO.File.Exists(filePath))
                return NotFound(new { message = "⚠️ Fichier CV non trouvé sur le serveur" });

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            var fileName = Path.GetFileName(filePath);

            return File(fileBytes, "application/pdf", fileName);
        }
    }
}

