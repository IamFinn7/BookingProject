using Domain.Entities;
using Domain.Repository;
using FluentValidation;
using Infrastructure.Helpers;
using Shared.Commands;

namespace Application.Hotels.Commands
{
    public record CreateHotelCommand(
        string Name,
        string OwnerId,
        string Address,
        string City,
        string Country,
        double StarRating,
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
                Hotel hotel = new()
                {
                    id = SystemHelper.RandomId(),
                    name = request.Name,
                    owner_id = request.OwnerId,
                    address = request.Address,
                    city = request.City,
                    country = request.Country,
                    star_rating = -1,
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
