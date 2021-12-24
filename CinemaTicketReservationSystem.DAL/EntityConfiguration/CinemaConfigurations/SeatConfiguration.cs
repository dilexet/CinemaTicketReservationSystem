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
                .HasOne(x => x.Ticket)
                .WithOne(x => x.Seat)
                .HasForeignKey<Seat>(x => x.TicketId);

            builder
                .HasOne(x => x.SeatType)
                .WithMany(x => x.Seat)
                .HasForeignKey(x => x.SeatTypeId);
        }
    }
}