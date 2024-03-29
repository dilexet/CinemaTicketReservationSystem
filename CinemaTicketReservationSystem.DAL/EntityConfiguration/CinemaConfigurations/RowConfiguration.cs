﻿using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.CinemaConfigurations
{
    public class RowConfiguration : IEntityTypeConfiguration<Row>
    {
        public void Configure(EntityTypeBuilder<Row> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Hall)
                .WithMany(x => x.Rows)
                .HasForeignKey(x => x.HallId);

            builder
                .HasMany(x => x.Seats)
                .WithOne(x => x.Row)
                .HasForeignKey(x => x.RowId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}