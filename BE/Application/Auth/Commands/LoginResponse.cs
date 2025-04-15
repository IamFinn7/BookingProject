namespace Application.Auth.Commands
{
    public class LoginResponse
    {
        public UserLoginResponse User { get; set; } = new();
        public Token Tokens { get; set; } = new();

        public class Token
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }

        public class UserLoginResponse
        {
            public string UserId { get; set; }
        }
    }
}
