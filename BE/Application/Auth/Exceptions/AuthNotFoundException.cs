using Shared.Exceptions;

namespace Application.Auth.Exceptions
{
    public class AuthNotFoundException : NotFoundException
    {
        public AuthNotFoundException(string email)
            : base($"User with email '{email}' was not found.") { }
    }
}
