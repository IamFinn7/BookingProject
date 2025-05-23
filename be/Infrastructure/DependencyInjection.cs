using Application.Interfaces.Repositories.Authentication;
using Application.Interfaces.Repositories.Common;
using Application.Interfaces.Repositories.Hotel;
using Application.Interfaces.Repositories.Room;
using Application.Interfaces.Repositories.System;
using Infrastructure.Repositories.Hotel;
using Infrastructure.Repositories.Room;
using Infrastructure.Repositories.System;
using Infrastructure.Security.TokenGenerator;
using Infrastructure.Security.TokenValidation;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services
                // .AddHttpContextAccessor()
                .AddServices()
                .AddAuthentication(configuration)
                // .AddAuthorization()
                .AddPersistence();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<MongoDBHelper>();
            services.AddSingleton<IKeyTokenRepository, KeyTokenRepository>();

            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelReviewRepository, HotelReviewRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            // services.AddScoped<IRoomFeatureRepository, RoomFeatureRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        private static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services
                .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            return services;
        }
    }
}
