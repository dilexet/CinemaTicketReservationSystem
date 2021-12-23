using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

#pragma warning disable SA1201
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore SA1201
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}