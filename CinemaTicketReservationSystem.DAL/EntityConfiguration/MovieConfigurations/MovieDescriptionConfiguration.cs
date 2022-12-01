using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.MovieConfigurations
{
    public class MovieDescriptionConfiguration : IEntityTypeConfiguration<MovieDescription>
    {
        public void Configure(EntityTypeBuilder<MovieDescription> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Movie)
                .WithOne(x => x.MovieDescription)
                .HasForeignKey<MovieDescription>(x => x.MovieId);
        }
    }
}