using Application.Hotel.Exceptions;
using Application.Interfaces.Repositories.Hotel;
using FluentValidation;
using Shared.Commands;

namespace Application.Hotel.Commands
{
    public record DeleteHotelReviewCommand(string Id) : ICommand<bool> { }

    public class DeleteHotelReviewCommandValidator : AbstractValidator<DeleteHotelReviewCommand>
    {
        public DeleteHotelReviewCommandValidator() { }
    }

    public class DeleteHotelReviewCommandHandler : ICommandHandler<DeleteHotelReviewCommand, bool>
    {
        private readonly IHotelReviewRepository _rep;

        public DeleteHotelReviewCommandHandler(IHotelReviewRepository rep)
        {
            _rep = rep;
        }

        public async Task<bool> Handle(
            DeleteHotelReviewCommand request,
            CancellationToken cancellationToken
        )
        {
            var isSuccess = await _rep.DeleteAsync(request.Id);
            if (!isSuccess)
                throw new HotelReviewNotFoundException(request.Id);

            return isSuccess;
        }
    }
}
