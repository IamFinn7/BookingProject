using Application.Common.Interfaces;
using Application.Hotel.Exceptions;
using Domain.Entities;
using Domain.Repository.Hotel;
using FluentValidation;
using Shared.Commands;

namespace Application.Hotel.Commands
{
    public record UpdateHotelReviewCommand(
        string Id,
        string UserId,
        int Cleanliness,
        int Location,
        int Service,
        int Facilities,
        string Comment
    ) : ICommand<bool> { }

    public class UpdateHotelReviewCommandValidator : AbstractValidator<UpdateHotelReviewCommand>
    {
        public UpdateHotelReviewCommandValidator() { }
    }

    public class UpdateHotelReviewCommandHandler : ICommandHandler<UpdateHotelReviewCommand, bool>
    {
        private readonly IHotelReviewRepository _rep;
        private readonly IHotelRatingService _ratingService;

        public UpdateHotelReviewCommandHandler(
            IHotelReviewRepository rep,
            IHotelRatingService ratingService
        )
        {
            _rep = rep;
            _ratingService = ratingService;
        }

        public async Task<bool> Handle(
            UpdateHotelReviewCommand request,
            CancellationToken cancellationToken
        )
        {
            HotelReviewEntity updated = new()
            {
                cleanliness = request.Cleanliness,
                location = request.Location,
                service = request.Service,
                facilities = request.Facilities,
                comment = request.Comment,
                updated_at = DateTime.Now.Ticks,
            };

            var isSuccess = await _rep.UpdateAsync(updated, request.Id);
            if (!isSuccess)
                throw new HotelReviewNotFoundException(request.Id);

            await _ratingService.RecalculateRatingAsync(updated.hotel_id);

            return true;
        }
    }
}
