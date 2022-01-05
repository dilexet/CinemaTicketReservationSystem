using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<AdditionalService> AdditionalServices { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Row> Rows { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieDescription> MovieDescriptions { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionAdditionalService> SessionAdditionalServices { get; set; }

        public DbSet<SessionSeatType> SessionSeatTypes { get; set; }

        public DbSet<SessionSeat> SessionSeats { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<BookedOrder> BookedOrders { get; set; }

#pragma warning disable SA1201
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore SA1201
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}