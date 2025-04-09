using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shipping.BL.Services.Imodel;
using Shipping.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.Services
{
    public class TokenGeneration : ITokenGeneration
    {
        private readonly AuthService _authService;
        private readonly IConfiguration _configuration;

        public TokenGeneration(AuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(ApplicationUser applicationUser, UserManager<ApplicationUser> userManager)
        {
            // Create claims (standard and custom)
            var autClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, applicationUser.Id),
            new Claim(ClaimTypes.Email, applicationUser.Email),
            new Claim(ClaimTypes.GivenName, applicationUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // Add roles as claims
            var roles = await userManager.GetRolesAsync(applicationUser);
            foreach (var role in roles)
            {
                autClaims.Add(new Claim(ClaimTypes.Role, role));

                var permissions = await _authService.GetRolePermissions(role);

                foreach (var permission in permissions)
                {
                    var permissionClaim = System.Text.Json.JsonSerializer.Serialize(permission);

                    autClaims.Add(new Claim("Permission_" + permission.pageName, permissionClaim));
                }


            }

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var credentials = new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: _configuration["JWT:Issuer"],
               audience: _configuration["JWT:Audience"],
               claims: autClaims,
               expires: DateTime.Now.AddHours(double.Parse(_configuration["JWT:ExpireDate"])), 
               signingCredentials: credentials
           );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenHandler;

        }
    }
}

