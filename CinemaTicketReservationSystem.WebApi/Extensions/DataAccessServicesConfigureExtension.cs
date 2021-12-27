using CinemaTicketReservationSystem.DAL.Abstract.Authorize;
using CinemaTicketReservationSystem.DAL.Abstract.Cinema;
using CinemaTicketReservationSystem.DAL.Abstract.Movie;
using CinemaTicketReservationSystem.DAL.Abstract.Session;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Repository.Authorize;
using CinemaTicketReservationSystem.DAL.Repository.Cinema;
using CinemaTicketReservationSystem.DAL.Repository.Movie;
using CinemaTicketReservationSystem.DAL.Repository.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.WebApi.Extensions
{
    public static class DataAccessServicesConfigureExtension
    {
        public static void AddDataAccessServicesToConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var sqlConnectionString = configuration.GetConnectionString("DataAccessMSSqlProvider");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(sqlConnectionString));

            services.AddScoped<IUserRepository>(provider =>
                new UserRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<UserRepository>>()));

            services.AddScoped<IRoleRepository>(provider =>
                new RoleRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<RoleRepository>>()));

            services.AddScoped<IRefreshTokenRepository>(provider =>
                new RefreshTokenRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<RefreshTokenRepository>>()));

            services.AddScoped<ICinemaRepository>(provider =>
                new CinemaRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<CinemaRepository>>()));

            services.AddScoped<IMovieRepository>(provider =>
                new MovieRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<MovieRepository>>()));

            services.AddScoped<ISessionRepository>(provider =>
                new SessionRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<SessionRepository>>()));
        }
    }
}