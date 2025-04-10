using Application.Hotels.Commands;
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

        public static CreateHotelResponse ToHotelFromCreate(this Hotel hotels)
        {
            return new CreateHotelResponse
            {
                Id = hotels.id,
                Name = hotels.name,
                OwnerId = hotels.owner_id,
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
