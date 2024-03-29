﻿using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.SessionConfigurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasOne(x => x.Hall)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.HallId);

            builder
                .HasMany(x => x.SessionAdditionalServices)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.SessionSeats)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.SessionSeatType)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId);
        }
    }
}