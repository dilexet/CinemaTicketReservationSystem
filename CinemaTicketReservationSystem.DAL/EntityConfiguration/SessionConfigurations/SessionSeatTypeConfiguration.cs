﻿using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
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
                .HasOne(x => x.SessionSeat)
                .WithOne(x => x.SessionSeatType)
                .HasForeignKey<SessionSeat>(x => x.SessionSeatTypeId);
        }
    }
}