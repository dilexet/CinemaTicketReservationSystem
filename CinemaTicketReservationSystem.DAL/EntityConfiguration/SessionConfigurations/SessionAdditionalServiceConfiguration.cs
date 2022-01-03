using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.SessionConfigurations
{
    public class SessionAdditionalServiceConfiguration : IEntityTypeConfiguration<SessionAdditionalService>
    {
        public void Configure(EntityTypeBuilder<SessionAdditionalService> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Session)
                .WithMany(x => x.SessionAdditionalServices)
                .HasForeignKey(x => x.SessionId);

            builder
                .HasOne(x => x.AdditionalService)
                .WithMany(x => x.SessionAdditionalServices)
                .HasForeignKey(x => x.AdditionalServiceId);
        }
    }
}