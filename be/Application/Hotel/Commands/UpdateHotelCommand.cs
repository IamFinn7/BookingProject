using Application.Hotel.Exceptions;
using Application.Interfaces.Repositories.Hotel;
using Domain.Entities;
using FluentValidation;
using Shared.Commands;

namespace Application.Hotel.Commands
{
    public record UpdateHotelCommand(
        string Id,
        string Name,
        string Address,
        string City,
        string Country,
        List<string> Amenities,
        List<string> Images
    ) : ICommand<bool> { }

    public class UpdateHotelCommandValidator : AbstractValidator<UpdateHotelCommand>
    {
        public UpdateHotelCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }

    public class UpdateHotelCommandHandler : ICommandHandler<UpdateHotelCommand, bool>
    {
        private readonly IHotelRepository _rep;

        public UpdateHotelCommandHandler(IHotelRepository rep)
        {
            _rep = rep;
        }

        public async Task<bool> Handle(
            UpdateHotelCommand request,
            CancellationToken cancellationToken
        )
        {
            HotelEntity updated = new()
            {
                name = request.Name,
                address = request.Address,
                city = request.City,
                country = request.Country,
                updated_at = DateTime.Now.Ticks,
            };

            var isSuccess = await _rep.UpdateAsync(request.Id, updated);
            if (!isSuccess)
                throw new HotelNotFoundException(request.Id);

            return true;
        }
    }
}
