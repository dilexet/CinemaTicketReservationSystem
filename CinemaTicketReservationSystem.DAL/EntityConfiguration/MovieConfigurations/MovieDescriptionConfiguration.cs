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

            builder.Ignore(x => x.Countries);
            builder.Ignore(x => x.Genres);
            builder.Ignore(x => x.Directors);
            builder.Ignore(x => x.Screenwriters);
            builder.Ignore(x => x.Producers);
            builder.Ignore(x => x.Actors);

            builder.Property(x => x.CountriesString).HasColumnName("Countries");
            builder.Property(x => x.GenresString).HasColumnName("Genres");
            builder.Property(x => x.DirectorsString).HasColumnName("Directors");
            builder.Property(x => x.ScreenwritersString).HasColumnName("Screenwriters");
            builder.Property(x => x.ProducersString).HasColumnName("Producers");
            builder.Property(x => x.ActorsString).HasColumnName("Actors");

            builder
                .HasOne(x => x.Movie)
                .WithOne(x => x.MovieDescription);
        }
    }
}