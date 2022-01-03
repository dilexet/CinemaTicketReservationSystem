using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.CinemaConfigurations
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.SeatTypes);

            builder
                .HasOne(x => x.Cinema)
                .WithMany(x => x.Halls)
                .HasForeignKey(x => x.CinemaId);

            builder
                .HasMany(x => x.Sessions)
                .WithOne(x => x.Hall)
                .HasForeignKey(x => x.HallId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Rows)
                .WithOne(x => x.Hall)
                .HasForeignKey(x => x.HallId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}