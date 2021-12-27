using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Services;
using CinemaTicketReservationSystem.BLL.Utils;
using CinemaTicketReservationSystem.DAL.Abstract.Authorize;
using CinemaTicketReservationSystem.DAL.Abstract.Cinema;
using CinemaTicketReservationSystem.DAL.Abstract.Movie;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CinemaTicketReservationSystem.WebApi.Extensions
{
    public static class BusinessLogicServicesConfigureExtension
    {
        public static void AddBusinessLogicServicesToConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.Configure<RefreshTokenOptions>(configuration.GetSection("RefreshTokenOptions"));

            services.AddScoped<IJwtService>(provider => new JwtService(provider.GetService<IOptions<JwtOptions>>()));

            services.AddScoped<IRefreshTokenService>(provider =>
                new RefreshTokenService(provider.GetService<IOptions<RefreshTokenOptions>>()));

            services.AddScoped<ITokenService>(provider => new TokenService(
                provider.GetService<IJwtService>(),
                provider.GetService<IRefreshTokenService>(),
                provider.GetService<IRefreshTokenRepository>()));

            services.AddScoped<IAuthorizeService>(provider =>
                new AuthorizeService(
                    provider.GetService<IUserRepository>(),
                    provider.GetService<IRoleRepository>(),
                    provider.GetService<ITokenService>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<IUserManagement>(provider =>
                new UserManagement(
                    provider.GetService<IUserRepository>(),
                    provider.GetService<IRoleRepository>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<IMovieService>(provider =>
                new MovieService(
                    provider.GetService<IMovieRepository>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<ICinemaService>(provider =>
                new CinemaService(
                    provider.GetService<ICinemaRepository>(),
                    provider.GetService<IMapper>()));
        }
    }
}