using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shopping.ApplicationService.DTO.Request.User;
using Shopping.ApplicationService.DTO.Response;
using Shopping.ApplicationService.Services.IService;
using Shopping.Contract;
using Shopping.Infrastructure;
using Shopping.Infrastructure.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Shopping.ApplicationService.Services {
    public class AuthService : IAuthService {
        private readonly ShoppingContext _context;
        private readonly IRepositoryWrapper _wrapper;
        private readonly IConfiguration _configuration;
        public AuthService(IRepositoryWrapper wrapper, IConfiguration configuration, ShoppingContext context) {
            _wrapper = wrapper;
            _configuration = configuration;
            _context = context;
        }
        public async Task<TokenResponse?> LoginAsync(LoginRequest login) {
            var userAccess = await _wrapper.UserRepository.GetUserByEmailAsync(login.Email);
            if (userAccess is null) {
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(userAccess, userAccess.Password, login.Password) == PasswordVerificationResult.Failed) {
                return null;
            }



            var tokenResponse = await CreateTokenResponse(userAccess);

            var handler = new JwtSecurityTokenHandler();
            var accessToken = handler.ReadJwtToken(tokenResponse.AccessToken);

            var expAccess = accessToken.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
            if (expAccess == null) {
                return null;
            }

            var accessTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expAccess)).UtcDateTime;
            userAccess.AccessToken = tokenResponse.AccessToken;
            userAccess.AccessTokenExpired = accessTime;
            _wrapper.UserRepository.UpdateUser(userAccess);
            _wrapper.Save();
            await _context.SaveChangesAsync();
            return tokenResponse;


        }

        public async Task<TokenResponse> CreateTokenResponse(User user) {
            return new TokenResponse {
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshTokenAsync(user)
            };
        }

        private string CreateToken(User user) {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Fullname),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        private string GenerateRefreshToken() {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> GenerateAndSaveRefreshTokenAsync(User user) {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpired = DateTime.UtcNow.AddSeconds(60);
            _wrapper.UserRepository.UpdateUser(user);
            _wrapper.Save();
            await _context.SaveChangesAsync();
            return refreshToken;
        }

        private User ValidateRefreshTokenAsync(int userId, string refreshToken) {
            var user = _wrapper.UserRepository.GetUserById(userId);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpired <= DateTime.UtcNow) {
                return null;
            }
            return user;

        }

        public async Task<TokenResponse?> RefreshTokenAsync(RefreshTokenRequest refreshToken) {
            var user = ValidateRefreshTokenAsync(refreshToken.UserId, refreshToken.RefreshToken);
            if (user is null) {
                return null;
            }

            return await CreateTokenResponse(user);
        }
    }
}
