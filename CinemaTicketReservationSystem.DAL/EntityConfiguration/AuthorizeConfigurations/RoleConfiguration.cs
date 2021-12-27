using System;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
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
                new
                {
                    Id = Guid.NewGuid(), Name = "Admin"
                },
                new
                {
                    Id = Guid.NewGuid(), Name = "Manager"
                },
                new
                {
                    Id = Guid.NewGuid(), Name = "User"
                });
        }
    }
}