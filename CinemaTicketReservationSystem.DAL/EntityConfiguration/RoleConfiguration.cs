using System;
using CinemaTicketReservationSystem.DAL.Entity;
using CinemaTicketReservationSystem.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new { Id = Guid.NewGuid(), Name = RoleTypes.Admin.ToString() },
                new { Id = Guid.NewGuid(), Name = RoleTypes.Manager.ToString() },
                new { Id = Guid.NewGuid(), Name = RoleTypes.User.ToString() });
        }
    }
}