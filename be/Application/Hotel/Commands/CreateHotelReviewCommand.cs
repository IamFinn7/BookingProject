using Application.Hotels;
using Application.Interfaces.Repositories.Hotel;
using Application.Interfaces.Services;
using Domain.Entities;
using FluentValidation;
using Shared.Commands;
using Shared.Helpers;

namespace Application.Hotel.Commands
{
    public record CreateHotelReviewCommand(
        string HotelId,
        string UserId,
        int Cleanliness,
        int Location,
        int Service,
        int Facilities,
        string? Comment
    ) : ICommand<CreateHotelReviewResponse> { }

    public class CreateHotelReviewCommandValidator : AbstractValidator<CreateHotelReviewCommand>
    {
        public CreateHotelReviewCommandValidator() { }
    }

    public class CreateHotelReviewCommandHandler
        : ICommandHandler<CreateHotelReviewCommand, CreateHotelReviewResponse>
    {
        private readonly IHotelReviewRepository _rep;
        private readonly IHotelRatingService _ratingService;

        public CreateHotelReviewCommandHandler(
            IHotelReviewRepository rep,
            IHotelRatingService ratingService
        )
        {
            _rep = rep;
            _ratingService = ratingService;
        }

        public async Task<CreateHotelReviewResponse> Handle(
            CreateHotelReviewCommand request,
            CancellationToken cancellationToken
        )
        {
            HotelReviewEntity review = new()
            {
                id = SystemHelper.RandomId(),
                hotel_id = request.HotelId,
                user_id = request.UserId,
                cleanliness = request.Cleanliness,
                location = request.Location,
                service = request.Service,
                facilities = request.Facilities,
                comment = request.Comment ?? "",
                created_at = DateTime.Now.Ticks,
            };

            var result = await _rep.AddAsync(review);
            await _ratingService.RecalculateRatingAsync(request.HotelId);

            return result.ToHotelReviewFromCreate();
        }
    }
}
