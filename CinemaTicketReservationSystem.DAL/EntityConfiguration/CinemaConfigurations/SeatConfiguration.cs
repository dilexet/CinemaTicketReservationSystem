using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
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
                .HasOne(x => x.SessionSeat)
                .WithOne(x => x.Seat)
                .HasForeignKey<SessionSeat>(x => x.SeatId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}