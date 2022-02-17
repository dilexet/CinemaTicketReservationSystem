using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.BookingConfigurations
{
    public class BookedOrderConfiguration : IEntityTypeConfiguration<BookedOrder>
    {
        public void Configure(EntityTypeBuilder<BookedOrder> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.UserProfile)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserProfileId);

            builder
                .HasMany(x => x.ReservedSessionSeats)
                .WithOne(x => x.BookedOrder)
                .HasForeignKey(x => x.BookedOrderId);

            builder
                .HasMany(x => x.SelectedAdditionalServices)
                .WithOne(x => x.BookedOrder)
                .HasForeignKey(x => x.BookedOrderId);
        }
    }
}