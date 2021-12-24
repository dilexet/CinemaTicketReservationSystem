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
                .HasOne(x => x.MovieDescription)
                .WithOne(x => x.Movie)
                .HasForeignKey<Movie>(x => x.MovieDescriptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}