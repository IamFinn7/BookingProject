namespace Application.Auth.Commands
{
    public record RefreshTokenResponse(string AccessToken, string RefreshToken);
}
