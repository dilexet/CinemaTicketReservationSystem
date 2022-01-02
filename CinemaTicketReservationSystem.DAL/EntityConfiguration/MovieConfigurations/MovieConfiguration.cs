using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.MovieConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Sessions)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasOne(x => x.MovieDescription)
                .WithOne(x => x.Movie)
                .HasForeignKey<MovieDescription>(x => x.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}