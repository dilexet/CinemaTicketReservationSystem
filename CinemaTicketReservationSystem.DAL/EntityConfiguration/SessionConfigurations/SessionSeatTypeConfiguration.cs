using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.SessionConfigurations
{
    public class SessionSeatTypeConfiguration : IEntityTypeConfiguration<SessionSeatType>
    {
        public void Configure(EntityTypeBuilder<SessionSeatType> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Session)
                .WithMany(x => x.SessionSeatType)
                .HasForeignKey(x => x.SessionId);

            builder
                .HasMany(x => x.SessionSeats)
                .WithOne(x => x.SessionSeatType)
                .HasForeignKey(x => x.SessionSeatTypeId);
        }
    }
}