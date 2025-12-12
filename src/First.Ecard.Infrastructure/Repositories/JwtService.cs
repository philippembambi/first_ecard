using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using First.Ecard.Domain.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Infrastructure.Repositories
{
    public class JwtService : IJwtService
    {
        public readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateAccessToken(Agent agent)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, agent.Id.ToString()),
                new Claim("email", agent.Email),
                new Claim("role", agent.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireMinutes = int.Parse(_config["Jwt:ExpireMinutes"]);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}