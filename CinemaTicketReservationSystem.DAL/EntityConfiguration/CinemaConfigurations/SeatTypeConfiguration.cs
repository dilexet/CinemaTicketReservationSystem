using System;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.CinemaConfigurations
{
    public class SeatTypeConfiguration : IEntityTypeConfiguration<SeatType>
    {
        public void Configure(EntityTypeBuilder<SeatType> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Seat)
                .WithOne(x => x.SeatType)
                .HasForeignKey(x => x.SeatTypeId);

            builder
                .HasOne(x => x.SessionSeatType)
                .WithOne(x => x.SeatType)
                .HasForeignKey<SessionSeatType>(x => x.SeatTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new SeatType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Private Suite"
                },
                new SeatType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Premiere Sofa"
                },
                new SeatType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Love Seat"
                },
                new SeatType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema chair"
                },
                new SeatType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Armchairs bags"
                },
                new SeatType()
                {
                    Id = Guid.NewGuid(),
                    Name = "VIP"
                });
        }
    }
}