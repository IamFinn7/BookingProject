using Application.Features.Hotels;
using Application.Helpers;
using Application.Interfaces.Repositories.Hotel;
using Application.Interfaces.Repositories.System;
using Domain.Entities.System;
using Shared.Helpers;
using Shared.Queries;

namespace Application.Features.Hotel.Queries
{
    public record GetHotels(
        string SortBy = "created_at:desc",
        int Page = 0,
        int Limit = int.MaxValue,
        string? SearchTerm = ""
    ) : IQuery<List<GetHotelsResponse>> { }

    public class GetHotelsHandler : IQueryHandler<GetHotels, List<GetHotelsResponse>>
    {
        private readonly IHotelRepository _hotelRep;
        private readonly IUserRepository _userRep;

        public GetHotelsHandler(IHotelRepository hotelRep, IUserRepository userRep)
        {
            _hotelRep = hotelRep;
            _userRep = userRep;
        }

        public async Task<List<GetHotelsResponse>> Handle(
            GetHotels request,
            CancellationToken cancellationToken
        )
        {
            FindCreterias findCreterias = new();

            if (!string.IsNullOrEmpty(request.SearchTerm))
                findCreterias.SearchTerm = AppHelper.ParseSearchQuery(request.SearchTerm);

            findCreterias.Limit = request.Limit;

            findCreterias.Page = request.Page;

            var sortBy = ApplicationHelper.ParseSortCriteria(request.SortBy);

            var hotels = await _hotelRep.GetAllAsync(findCreterias, sortBy);

            var results = new List<GetHotelsResponse>();

            foreach (var hotel in hotels)
            {
                var response = hotel.ToGetHotelsResponse();

                var ownerName = await _userRep.GetUserNameByIdAsync(hotel.owner_id);
                response.OwnerName = ownerName ?? "Unknown";

                results.Add(response);
            }

            return results;
        }
    }
}
