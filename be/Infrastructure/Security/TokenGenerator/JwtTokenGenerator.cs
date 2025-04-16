using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces.Repositories.Authentication;
using Application.Interfaces.Repositories.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security.TokenGenerator
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _datetimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {
            _datetimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(string userId, string email, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Email, email),
                new("id", userId.ToString()),
                new(ClaimTypes.Role, role),
            };

            // roles.ForEach(role => claims.Add(new(ClaimTypes.Role, role)));
            // permissions.ForEach(permission => claims.Add(new("permissions", permission)));

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                expires: _datetimeProvider.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
                claims: claims,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken(string userId)
        {
            // Tạo refresh token (refresh token có thể chỉ là một chuỗi ngẫu nhiên)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> { new("id", userId) };

            var refreshToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                expires: _datetimeProvider.UtcNow.AddMinutes(
                    _jwtSettings.RefreshTokenExpirationInMinutes
                ),
                claims: claims,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(refreshToken);
        }

        public ClaimsPrincipal? ValidateRefreshToken(string refreshToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

                var validationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false, // Vì chỉ cần kiểm tra tính hợp lệ, không kiểm tra hạn
                    ClockSkew = TimeSpan.Zero,
                };

                var principal = tokenHandler.ValidateToken(
                    refreshToken,
                    validationParameters,
                    out var validatedToken
                );

                // Kiểm tra định dạng token hợp lệ
                if (
                    validatedToken is not JwtSecurityToken jwtToken
                    || !jwtToken.Header.Alg.Equals(
                        SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase
                    )
                )
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
