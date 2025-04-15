using Shared.Exceptions;

namespace Application.Auth.Exceptions
{
    public class InvalidAuthCredentialsException : AuthorizedException
    {
        public InvalidAuthCredentialsException()
            : base("Invalid email or password.") { }
    }
}