using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Services;
using CinemaTicketReservationSystem.BLL.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketReservationSystem.WebApi.Extensions.StartupConfigurations
{
    public static class BusinessLogicServicesConfigureExtension
    {
        public static void AddBusinessLogicServicesToConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.Configure<RefreshTokenOptions>(configuration.GetSection("RefreshTokenOptions"));

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IAdditionalServiceManagement, AdditionalServiceManagement>();

            services.AddScoped<IAuthorizeService, AuthorizeService>();

            services.AddScoped<IBookingService, BookingService>();

            services.AddScoped<ICinemaService, CinemaService>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IHallService, HallService>();

            services.AddScoped<IMovieFilterService, MovieFilterService>();

            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<ISeatTypeService, SeatTypeService>();

            services.AddScoped<ISessionService, SessionService>();

            services.AddScoped<IUserManagementService, UserManagementService>();

            services.AddScoped<IUserProfileService, UserProfileService>();
        }
    }
}