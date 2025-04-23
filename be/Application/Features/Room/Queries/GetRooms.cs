using Application.Helpers;
using Application.Interfaces.Repositories.Room;
using Domain.Entities.System;
using Shared.Queries;

namespace Application.Features.Room.Queries
{
    public record GetRooms(
        string hotelId,
        string SortBy = "created_at:desc",
        int Page = 0,
        int Limit = int.MaxValue
    ) : IQuery<List<GetRoomsResponse>> { }

    public class GetRoomsHandler : IQueryHandler<GetRooms, List<GetRoomsResponse>>
    {
        private readonly IRoomRepository _rep;

        public GetRoomsHandler(IRoomRepository rep)
        {
            _rep = rep;
        }

        public async Task<List<GetRoomsResponse>> Handle(
            GetRooms request,
            CancellationToken cancellationToken
        )
        {
            FindCreterias findCreterias = new();

            findCreterias.Limit = request.Limit;

            findCreterias.Page = request.Page;

            var sortBy = ApplicationHelper.ParseSortCriteria(request.SortBy);

            var result = await _rep.GetAllByHotelIdAsync(request.hotelId,findCreterias, sortBy);

            return result.Select(x => x.ToGetRoomsResponse()).ToList();
        }
    }
}
