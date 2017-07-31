using Leto.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Leto.Api.Services
{
    public class AuthService : IAuthService
    {
        private const string Secret = "wXeJJzgqBM8tHCPHtbMQJtDv4hbjxk8k";

        public string CreateToken(string userEmail)
        {
            var key = Convert.FromBase64String(Secret);
            var handler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userEmail)
                }),
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = handler.CreateToken(descriptor);
            var token = handler.WriteToken(securityToken);

            return token;
        }
    }
}