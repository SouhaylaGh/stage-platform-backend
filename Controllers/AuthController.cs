using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StageConnect.Data;
using StageConnect.DTOs;
using StageConnect.Models;
using StageConnect.Services;

namespace StageConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;


        public AuthController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            TokenService tokenService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("signup/student")]
        public async Task<IActionResult> SignupStudent([FromBody] SignupStudentDto dto)
        {
            var existing = await _userManager.FindByEmailAsync(dto.Email);
            if (existing != null) return BadRequest("Email déjà utilisé.");

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Prenom = dto.Prenom,
                Nom = dto.Nom,
                PhoneNumber = dto.Telephone,
                Ville = dto.Ville,
                NiveauEtude = dto.NiveauEtude,
                DomaineEtude = dto.DomaineEtude,
                Role = "Student"
            };

            var result = await _userManager.CreateAsync(user, dto.MotDePasse);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return BadRequest(errors);
            }

            var (token, expiration) = _tokenService.GenerateToken(user);
            return Ok(new AuthResponseDto { Token = token, Expiration = expiration, UserId = user.Id, Role = user.Role });
        }

        [HttpPost("signup/entreprise")]
        public async Task<IActionResult> SignupEntreprise([FromBody] SignupEntrepriseDto dto)
        {
            var existing = await _userManager.FindByEmailAsync(dto.EmailPro);
            if (existing != null) return BadRequest("Email déjà utilisé.");

            var user = new ApplicationUser
            {
                UserName = dto.EmailPro,
                Email = dto.EmailPro,
                EmailPro = dto.EmailPro,
                NomEntreprise = dto.NomEntreprise,
                SecteurActivite = dto.SecteurActivite,
                TailleEntreprise = dto.TailleEntreprise,
                DescriptionEntreprise = dto.DescriptionEntreprise,
                NomContact = dto.NomContact,
                PhoneNumber = dto.Telephone,
                SiteWeb = dto.SiteWeb,
                Adresse = dto.Adresse,
                Ville = dto.Ville,
                Role = "Entreprise"
            };

            var result = await _userManager.CreateAsync(user, dto.MotDePasse);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return BadRequest(errors);
            }

            var (token, expiration) = _tokenService.GenerateToken(user);
            return Ok(new AuthResponseDto { Token = token, Expiration = expiration, UserId = user.Id, Role = user.Role });
        }

        [HttpPost("login/student")]
        public async Task<IActionResult> LoginStudent([FromBody] LoginStudentDto dto)
        {
            // Vérifier si l'email et le mot de passe sont fournis
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Email et mot de passe sont requis.");

            //var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && u.Role == "Student");
            // Chercher l'étudiant par Email (en évitant les erreurs si Email est null en DB)
            var user = await _context.Users
                .Where(u => u.Role == "Student" && u.Email != null && u.Email == dto.Email)
                .FirstOrDefaultAsync();

            if (user == null)
                return Unauthorized("Étudiant introuvable");

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);

            if (!result.Succeeded)
                return Unauthorized("Mot de passe incorrect");

            var (token, expiration) = _tokenService.GenerateToken(user);
            return Ok(new AuthResponseDto
            {
                Token = token,
                Expiration = expiration,
                UserId = user.Id,
                Role = user.Role
            });
        }

        [HttpPost("login/company")]
        public async Task<IActionResult> LoginCompany([FromBody] LoginCompanyDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.EmailPro) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Email et mot de passe sont requis.");

            // var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailPro == dto.EmailPro && u.Role == "Entreprise");
            var user = await _context.Users
              .Where(u => u.Role == "Entreprise" &&
                   ((u.EmailPro != null && u.EmailPro == dto.EmailPro) ||
                    (u.Email != null && u.Email == dto.EmailPro)))
              .FirstOrDefaultAsync();


            if (user == null)
                return Unauthorized("Entreprise introuvable");

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);

            if (!result.Succeeded)
                return Unauthorized("Mot de passe incorrect");

            var (token, expiration) = _tokenService.GenerateToken(user);
            return Ok(new AuthResponseDto
            {
                Token = token,
                Expiration = expiration,
                UserId = user.Id,
                Role = user.Role
            });
        }


    }
}

