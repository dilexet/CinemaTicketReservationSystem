using System;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.CinemaConfigurations
{
    public class SeatTypeConfiguration : IEntityTypeConfiguration<SeatType>
    {
        public void Configure(EntityTypeBuilder<SeatType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Love Seat"
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Rest Sofa"
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Premiere Sofa"
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Private Suite"
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Bag Chair"
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "VIP"
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Regular"
                });
        }
    }
}