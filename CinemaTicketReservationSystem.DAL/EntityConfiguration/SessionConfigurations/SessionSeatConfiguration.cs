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
                .WithOne(x => x.SessionSeat)
                .HasForeignKey<SessionSeatType>(x => x.SessionSeatId);

            builder
                .HasOne(x => x.Session)
                .WithMany(x => x.SessionSeats)
                .HasForeignKey(x => x.SessionId);

            builder
                .HasOne(x => x.Seat)
                .WithOne(x => x.SessionSeat)
                .HasForeignKey<SessionSeat>(x => x.SeatId);
        }
    }
}