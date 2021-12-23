using System;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketReservationSystem.DAL.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsUnicode();

            builder
                .HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);

            builder.HasData(
                new
                {
                    Id = Guid.NewGuid(), Name = RoleTypes.Admin.ToString()
                },
                new
                {
                    Id = Guid.NewGuid(), Name = RoleTypes.Manager.ToString()
                },
                new
                {
                    Id = Guid.NewGuid(), Name = RoleTypes.User.ToString()
                });
        }
    }
}