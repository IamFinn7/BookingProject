using Application.Hotel.Exceptions;
using Application.Interfaces.Repositories.Hotel;
using FluentValidation;
using Shared.Commands;

namespace Application.Hotel.Commands
{
    public record DeleteHotelCommand(string Id) : ICommand<bool> { }

    public class DeleteHotelCommandValidator : AbstractValidator<DeleteHotelCommand>
    {
        public DeleteHotelCommandValidator() { }
    }

    public class DeleteHotelCommandHandler : ICommandHandler<DeleteHotelCommand, bool>
    {
        private readonly IHotelRepository _rep;

        public DeleteHotelCommandHandler(IHotelRepository rep)
        {
            _rep = rep;
        }

        public async Task<bool> Handle(
            DeleteHotelCommand request,
            CancellationToken cancellationToken
        )
        {
            var isSuccess = await _rep.DeleteAsync(request.Id);
            if (!isSuccess)
                throw new HotelNotFoundException(request.Id);

            return isSuccess;
        }
    }
}
