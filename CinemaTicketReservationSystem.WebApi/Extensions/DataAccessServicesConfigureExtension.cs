using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Repository;
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

            services.AddScoped<IRepository<Role>>(provider =>
                new BaseRepository<Role>(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<BaseRepository<Role>>>()));

            services.AddScoped<IRepository<RefreshToken>>(provider =>
                new BaseRepository<RefreshToken>(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<BaseRepository<RefreshToken>>>()));

            services.AddScoped<IRepository<Cinema>>(provider =>
                new BaseRepository<Cinema>(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<BaseRepository<Cinema>>>()));

            services.AddScoped<IRepository<Movie>>(provider =>
                new BaseRepository<Movie>(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<BaseRepository<Movie>>>()));

            services.AddScoped<IRepository<Session>>(provider =>
                new BaseRepository<Session>(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<BaseRepository<Session>>>()));

            services.AddScoped<IRepository<AdditionalService>>(provider =>
                new BaseRepository<AdditionalService>(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<BaseRepository<AdditionalService>>>()));

            services.AddScoped<IRepository<Hall>>(provider =>
                new BaseRepository<Hall>(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<BaseRepository<Hall>>>()));
        }
    }
}