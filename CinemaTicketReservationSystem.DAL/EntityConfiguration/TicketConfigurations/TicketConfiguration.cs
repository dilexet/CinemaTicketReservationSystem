using CinemaTicketReservationSystem.DAL.Entity.TicketsEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.TicketConfigurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Session)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.SessionId);

            builder
                .HasOne(x => x.Seat)
                .WithOne(x => x.Ticket)
                .HasForeignKey<Ticket>(x => x.SeatId);

            builder
                .HasMany(x => x.AdditionalServices)
                .WithOne(x => x.Ticket)
                .HasForeignKey(x => x.TicketId);
        }
    }
}