using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.SessionConfigurations
{
    public class SessionSeatConfiguration : IEntityTypeConfiguration<SessionSeat>
    {
        public void Configure(EntityTypeBuilder<SessionSeat> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.SessionSeatType)
                .WithMany(x => x.SessionSeats)
                .HasForeignKey(x => x.SessionSeatTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Session)
                .WithMany(x => x.SessionSeats)
                .HasForeignKey(x => x.SessionId);

            builder
                .HasOne(x => x.Seat)
                .WithMany(x => x.SessionSeats)
                .HasForeignKey(x => x.SeatId);

            builder
                .HasOne(x => x.BookedOrder)
                .WithMany(x => x.ReservedSessionSeats)
                .HasForeignKey(x => x.BookedOrderId);
        }
    }
}