using Shared.Exceptions;

namespace Application.Features.Hotel.Exceptions
{
    public class HotelNotFoundException : NotFoundException
    {
        public HotelNotFoundException(string id)
            : base($"Hotel with ID {id} was not found.") { }
    }
}
