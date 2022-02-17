using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.BookingConfigurations
{
    public class BookedServiceConfiguration : IEntityTypeConfiguration<BookedService>
    {
        public void Configure(EntityTypeBuilder<BookedService> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.BookedOrder)
                .WithMany(x => x.SelectedAdditionalServices)
                .HasForeignKey(x => x.BookedOrderId);

            builder
                .HasOne(x => x.SelectedSessionAdditionalService)
                .WithMany(x => x.BookedServices)
                .HasForeignKey(x => x.SessionAdditionalServiceId);
        }
    }
}