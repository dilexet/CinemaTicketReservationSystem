using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.CinemaConfigurations
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Sessions)
                .WithOne(x => x.Hall)
                .HasForeignKey(x => x.HallId);

            builder
                .HasMany(x => x.Rows)
                .WithOne(x => x.Hall)
                .HasForeignKey(x => x.HallId);
        }
    }
}