using Microsoft.AspNetCore.Mvc;
using StageConnect.Data;
using StageConnect.DTOs;
using StageConnect.Models;
using System.Text.Json;

namespace StageConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InternshipOffersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InternshipOffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/InternshipOffers
        [HttpPost("create")]
        public IActionResult CreateOffer([FromBody] InternshipOfferDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            var offer = new InternshipOffer
            {
                Title = dto.Title,
                Domain = dto.Domain,
                Level = dto.Level,
                Description = dto.Description,
                City = dto.City,
                Mode = dto.Mode,
                Address = dto.Address,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Duration = dto.Duration,
                Profile = dto.Profile,
                Competences = dto.Competences,
                Languages = dto.Languages,
                Salary = dto.Salary,
                Positions = dto.Positions,
                Benefits = dto.Benefits,
                Urgent = dto.Urgent,
                Remote = dto.Remote,
                Housing = dto.Housing,
                ContactName = dto.ContactName,
                ContactEmail = dto.ContactEmail,
                Instructions = dto.Instructions,
                Skills = JsonSerializer.Serialize(dto.Skills) // Convert list to JSON
            };

            _context.InternshipOffers.Add(offer);
            _context.SaveChanges();

            return Ok(new { message = "✅ Offre créée avec succès !", offer.Id });
        }

        // GET: api/InternshipOffers
        [HttpGet("all")]
        public IActionResult GetAllOffers()
        {
            var offers = _context.InternshipOffers.ToList();
            return Ok(offers);
        }

        // GET: api/InternshipOffers/5
        [HttpGet("{id}")]
        public IActionResult GetOffer(int id)
        {
            var offer = _context.InternshipOffers.Find(id);
            if (offer == null) return NotFound();
            return Ok(offer);
        }
    }
}

