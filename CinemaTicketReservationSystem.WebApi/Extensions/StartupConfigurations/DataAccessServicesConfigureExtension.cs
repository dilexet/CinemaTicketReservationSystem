using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;
using CinemaTicketReservationSystem.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketReservationSystem.WebApi.Extensions.StartupConfigurations
{
    public static class DataAccessServicesConfigureExtension
    {
        public static void AddDataAccessServicesToConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var sqlConnectionString = configuration.GetConnectionString("Postgres");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(sqlConnectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Role>, BaseRepository<Role>>();
            services.AddScoped<IRepository<RefreshToken>, BaseRepository<RefreshToken>>();

            services.AddScoped<IRepository<BookedOrder>, BaseRepository<BookedOrder>>();
            services.AddScoped<IRepository<BookedService>, BaseRepository<BookedService>>();

            services.AddScoped<IRepository<AdditionalService>, BaseRepository<AdditionalService>>();
            services.AddScoped<IRepository<Address>, BaseRepository<Address>>();
            services.AddScoped<IRepository<Cinema>, BaseRepository<Cinema>>();
            services.AddScoped<IRepository<Hall>, BaseRepository<Hall>>();

            services.AddScoped<IRepository<Movie>, BaseRepository<Movie>>();
            services.AddScoped<IRepository<Genre>, BaseRepository<Genre>>();
            services.AddScoped<IRepository<Country>, BaseRepository<Country>>();

            services.AddScoped<IRepository<Session>, BaseRepository<Session>>();
            services.AddScoped<IRepository<SessionAdditionalService>, BaseRepository<SessionAdditionalService>>();
            services.AddScoped<IRepository<SessionSeat>, BaseRepository<SessionSeat>>();
            services.AddScoped<IRepository<SessionSeatType>, BaseRepository<SessionSeatType>>();

            services.AddScoped<IRepository<UserProfile>, BaseRepository<UserProfile>>();
        }
    }
}