using System;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration.AuthorizeConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);

            builder.HasData(
                new Role
                {
                    Id = Guid.NewGuid(), Name = RoleTypes.Admin.ToString(), Deleted = false
                },
                new Role
                {
                    Id = Guid.NewGuid(), Name = RoleTypes.Manager.ToString(), Deleted = false
                },
                new Role
                {
                    Id = Guid.NewGuid(), Name = RoleTypes.User.ToString(), Deleted = false
                });
        }
    }
}