using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repository
{
    /// <summary>
    /// Responsible for generating JWT tokens for authenticated users.
    /// Uses IConfiguration to read signing settings from appsettings.json.
    /// </summary>
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserApp userApp)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userApp.UserName),
                new Claim("firstName", userApp.FirstName),
                new Claim("LastNameName", userApp.LastName)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["issuer"],
                audience: jwtSettings["audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
