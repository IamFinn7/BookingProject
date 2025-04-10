using Application.Hotels.Queries;
using Domain.Entities;

namespace Application.Hotels
{
    public static class HotelMapper
    {
        public static GetHotelsResponse ToGetHotelsResponse(this Hotel hotels)
        {
            return new GetHotelsResponse
            {
                Id = hotels.id,
                Name = hotels.name,
                Address = hotels.address,
                City = hotels.city,
                Country = hotels.country,
                StarRating = hotels.star_rating,
                Amenities = hotels.amenities,
                Images = hotels.images,
            };
        }
    }
}
