using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Services;
using CinemaTicketReservationSystem.BLL.Utils;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using Microsoft.AspNetCore.Hosting;
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
                provider.GetService<IRepository<RefreshToken>>()));

            services.AddScoped<IAuthorizeService>(provider =>
                new AuthorizeService(
                    provider.GetService<IUserRepository>(),
                    provider.GetService<IRepository<Role>>(),
                    provider.GetService<ITokenService>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<IUserService>(provider =>
                new UserService(
                    provider.GetService<IUserRepository>(),
                    provider.GetService<IRepository<Role>>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<IMovieService>(provider =>
                new MovieService(
                    provider.GetService<IRepository<Movie>>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<ICinemaService>(provider =>
                new CinemaService(
                    provider.GetService<IRepository<Cinema>>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<ISeatTypeService, SeatTypeService>();

            services.AddScoped<IAdditionalServiceManagement>(provider =>
                new AdditionalServiceManagement(
                    provider.GetService<IRepository<AdditionalService>>(),
                    provider.GetService<IRepository<Cinema>>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<IHallService>(provider =>
                new HallService(
                    provider.GetService<IRepository<Hall>>(),
                    provider.GetService<IRepository<Cinema>>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<ISessionService>(provider =>
                new SessionService(
                    provider.GetService<IRepository<Session>>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<IFileService>(provider =>
                new FileService(
                    provider.GetService<IWebHostEnvironment>()));
        }
    }
}