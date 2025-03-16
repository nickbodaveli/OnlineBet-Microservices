using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Hub.Application.Data;
using Hub.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hub.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public UserRepository(UserManager<User> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        // Register new user
        public async Task<bool> RegisterUser(RegisterUser user)
        {
            var identityUser = new User
            {
                UserName = user.UserName,
                Email = user.UserName
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }

        // Login user and issue JWT token
        public async Task<LoginResponse> Login(LoginUser user)
        {
            var response = new LoginResponse();
            var identityUser = await _userManager.FindByEmailAsync(user.UserName);

            if (identityUser is null || (await _userManager.CheckPasswordAsync(identityUser, user.Password)) == false)
            {
                return response;
            }

            response.IsLogedIn = true;
            response.JwtToken = this.GenerateTokenString(identityUser.Email);
            response.SetRefreshToken(this.GenerateRefreshTokenString());

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.AddHours(12); // 12 hours expiration for refresh token
            await _userManager.UpdateAsync(identityUser);

            return response;
        }

        // Refresh token logic
        public async Task<LoginResponse> RefreshToken(RefreshTokenModel model)
        {
            var principal = GetTokenPrincipal(model.JwtToken);

            var response = new LoginResponse();
            if (principal?.Identity?.Name is null)
                return response;

            var identityUser = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (identityUser is null || identityUser.RefreshToken != model.RefreshToken || identityUser.RefreshTokenExpiry < DateTime.Now)
                return response;

            response.IsLogedIn = true;
            response.JwtToken = this.GenerateTokenString(identityUser.Email);
            response.SetRefreshToken(this.GenerateRefreshTokenString());

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.AddHours(12); // 12 hours expiration for refresh token
            await _userManager.UpdateAsync(identityUser);

            return response;
        }

        // Validate the token and return the principal (user identity)
        private ClaimsPrincipal? GetTokenPrincipal(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var validation = new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateLifetime = true,  // Enabling token expiration validation
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false,
            };
            try
            {
                return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Generate the refresh token (used for obtaining a new JWT token)
        private string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[64];

            using (var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }

        // Generate JWT token with 30-minute expiration
        private string GenerateTokenString(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, "Admin"), // Replace with dynamic role if available
                new Claim(ClaimTypes.NameIdentifier, "123") // Replace with actual user ID
            };

            var staticKey = _config.GetSection("Jwt:Key").Value;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(staticKey));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                issuer: _config.GetSection("Jwt:Issuer").Value, // Add issuer
                audience: _config.GetSection("Jwt:Audience").Value, // Add audience
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Token expires in 30 minutes
                signingCredentials: signingCred
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
