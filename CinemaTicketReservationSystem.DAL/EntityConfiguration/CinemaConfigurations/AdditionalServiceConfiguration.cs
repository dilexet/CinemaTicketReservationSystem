using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
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
                .HasOne(x => x.Cinema)
                .WithMany(x => x.AdditionalServices)
                .HasForeignKey(x => x.CinemaId);

            builder
                .HasOne(x => x.SessionAdditionalService)
                .WithOne(x => x.AdditionalService)
                .HasForeignKey<SessionAdditionalService>(x => x.AdditionalServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}