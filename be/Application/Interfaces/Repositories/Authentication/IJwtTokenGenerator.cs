using System.Security.Claims;

namespace Application.Interfaces.Repositories.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId, string email, string role);
        string GenerateRefreshToken(string userId);
        ClaimsPrincipal? ValidateRefreshToken(string refreshToken);
    }
}
