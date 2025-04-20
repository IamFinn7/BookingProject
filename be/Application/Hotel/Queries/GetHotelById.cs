using Application.Hotel.Exceptions;
using Application.Hotels;
using Application.Interfaces.Repositories.Hotel;
using Application.Interfaces.Repositories.System;
using Shared.Queries;

namespace Application.Hotel.Queries
{
    public record GetHotelById(string Id) : IQuery<GetHotelByIdResponse> { }

    public class GetHotelByIdHandler : IQueryHandler<GetHotelById, GetHotelByIdResponse>
    {
        private readonly IHotelRepository _hotelRep;
        private readonly IUserRepository _userRep;

        public GetHotelByIdHandler(IHotelRepository hotelRep, IUserRepository userRep)
        {
            _hotelRep = hotelRep;
            _userRep = userRep;
        }

        public async Task<GetHotelByIdResponse> Handle(
            GetHotelById request,
            CancellationToken cancellationToken
        )
        {
            var hotel = await _hotelRep.GetByIdAsync(request.Id);

            if (hotel == null)
            {
                throw new HotelNotFoundException(request.Id);
            }

            var result = hotel.ToGetHotelByIdResponse();
            var ownerName = await _userRep.GetUserNameByIdAsync(hotel.owner_id);
            result.OwnerName = ownerName ?? "Unknown";

            return result;
        }
    }
}
