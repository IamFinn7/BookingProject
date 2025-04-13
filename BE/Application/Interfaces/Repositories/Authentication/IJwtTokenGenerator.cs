namespace Application.Interfaces.Repositories.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId, string email, string role);
    }
}
