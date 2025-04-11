using Application.Hotels;
using Domain.Entities;
using Domain.Repository.Hotel;
using FluentValidation;
using Infrastructure.Helpers;
using Shared.Commands;

namespace Application.Hotel.Commands
{
    public record CreateHotelCommand(
        string Name,
        string OwnerId,
        string Address,
        string City,
        string Country,
        List<string> Amenities,
        List<string> Images
    ) : ICommand<CreateHotelResponse> { }

    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
        }

        public class CreateHotelCommandHandler
            : ICommandHandler<CreateHotelCommand, CreateHotelResponse>
        {
            private readonly IHotelRepository _rep;

            public CreateHotelCommandHandler(IHotelRepository rep)
            {
                _rep = rep;
            }

            public async Task<CreateHotelResponse> Handle(
                CreateHotelCommand request,
                CancellationToken cancellationToken
            )
            {
                HotelEntity hotel = new()
                {
                    id = SystemHelper.RandomId(),
                    name = request.Name,
                    owner_id = request.OwnerId,
                    address = request.Address,
                    city = request.City,
                    country = request.Country,
                    amenities = request.Amenities,
                    images = request.Images,
                    created_at = DateTime.Now.Ticks,
                };

                var result = await _rep.AddAsync(hotel);
                return result.ToHotelFromCreate();
            }
        }
    }
}
