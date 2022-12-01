using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.CinemaConfigurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name).IsUnique();

            builder
                .HasOne(x => x.Address)
                .WithOne(x => x.Cinema)
                .HasForeignKey<Address>(x => x.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.AdditionalServices)
                .WithOne(x => x.Cinema)
                .HasForeignKey(x => x.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Halls)
                .WithOne(x => x.Cinema)
                .HasForeignKey(x => x.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}