using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.CinemaConfigurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Row)
                .WithMany(x => x.Seats)
                .HasForeignKey(x => x.RowId);

            builder
                .HasMany(x => x.SessionSeats)
                .WithOne(x => x.Seat)
                .HasForeignKey(x => x.SeatId);
        }
    }
}