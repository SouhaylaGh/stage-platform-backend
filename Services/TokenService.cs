using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StageConnect.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StageConnect.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public (string token, DateTime expiration) GenerateToken(ApplicationUser user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");
            var issuer = jwtSettings.GetValue<string>("Issuer");
            var audience = jwtSettings.GetValue<string>("Audience");
            var expiryMinutes = jwtSettings.GetValue<int>("ExpiryMinutes");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim("roleType", user.Role ?? ""),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(expiryMinutes);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expiration,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return (tokenString, expiration);
        }
    }
}
