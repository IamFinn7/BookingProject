using Shared.Exceptions;

namespace Application.Auth.Exceptions
{
    public class AuthNotFoundException : NotFoundException
    {
        public AuthNotFoundException(string id)
            : base($"User with ID {id} was not found.") { }
    }

    // public class HotelAlreadyExistsException : ConflictException
    // {
    //     public HotelAlreadyExistsException(string name)
    //         : base($"Hotel '{name}' already exists.") { }
    // }
}
