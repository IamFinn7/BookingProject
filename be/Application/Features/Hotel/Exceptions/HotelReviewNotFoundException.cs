using Shared.Exceptions;

namespace Application.Features.Hotel.Exceptions
{
    public class HotelReviewNotFoundException : NotFoundException
    {
        public HotelReviewNotFoundException(string id)
            : base($"Hotel's review with ID {id} was not found.") { }
    }
}
