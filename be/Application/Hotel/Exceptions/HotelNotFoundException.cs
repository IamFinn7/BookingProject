using Shared.Exceptions;

namespace Application.Hotel.Exceptions
{
    public class HotelNotFoundException : NotFoundException
    {
        public HotelNotFoundException(string id)
            : base($"Hotel with ID {id} was not found.") { }
    }
}
