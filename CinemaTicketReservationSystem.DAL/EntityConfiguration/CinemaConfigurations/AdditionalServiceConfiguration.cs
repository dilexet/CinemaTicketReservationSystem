using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.CinemaConfigurations
{
    public class AdditionalServiceConfiguration : IEntityTypeConfiguration<AdditionalService>
    {
        public void Configure(EntityTypeBuilder<AdditionalService> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Ticket)
                .WithMany(x => x.AdditionalServices)
                .HasForeignKey(x => x.TicketId);

            builder
                .HasOne(x => x.SessionAdditionalService)
                .WithOne(x => x.AdditionalService)
                .HasForeignKey<AdditionalService>(x => x.SessionAdditionalServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}