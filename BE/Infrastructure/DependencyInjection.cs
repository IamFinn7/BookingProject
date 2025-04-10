using Domain.Repository;
using Domain.Repository.Hotel;
using Infrastructure.Repository;
using Infrastructure.Repository.Hotel;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MongoDBHelper>();

            services.AddScoped<IHotelRepository, HotelRepository>();
			services.AddScoped<IHotelReviewRepository, HotelReviewRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
