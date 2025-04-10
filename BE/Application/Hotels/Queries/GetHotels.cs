using Application.Helpers;
using Domain.Entities.System;
using Domain.Repository;
using Shared.Helpers;
using Shared.Queries;

namespace Application.Hotels.Queries
{
    public record GetHotels(
        string SortBy = "created_at:desc",
        int Page = 0,
        int Limit = int.MaxValue,
        string? SearchTerm = ""
    ) : IQuery<List<GetHotelsResponse>> { }

    public class GetHotelsHandler : IQueryHandler<GetHotels, List<GetHotelsResponse>>
    {
        private readonly IHotelRepository _rep;

        public GetHotelsHandler(IHotelRepository rep)
        {
            _rep = rep;
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

            var result = await _rep.GetAllAsync(findCreterias, sortBy);

            return result.Select(x => x.ToGetHotelsResponse()).ToList();
        }
    }
}
