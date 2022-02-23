using System;
using System.Linq;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketReservationSystem.DAL.Initializers
{
    public static class RoleInitialize
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role
                    {
                        Deleted = false,
                        Name = RoleTypes.Admin.ToString(),
                    },
                    new Role
                    {
                        Deleted = false,
                        Name = RoleTypes.Manager.ToString(),
                    },
                    new Role
                    {
                        Deleted = false,
                        Name = RoleTypes.User.ToString(),
                    });

                context.SaveChanges();
            }
            else
            {
                if (context.Roles.FirstOrDefault(x => x.Name.Equals(RoleTypes.Admin.ToString())) == null)
                {
                    context.Roles.Add(new Role
                    {
                        Deleted = false,
                        Name = RoleTypes.Admin.ToString()
                    });
                }

                if (context.Roles.FirstOrDefault(x => x.Name.Equals(RoleTypes.Manager.ToString())) == null)
                {
                    context.Roles.Add(new Role
                    {
                        Deleted = false,
                        Name = RoleTypes.Manager.ToString()
                    });
                }

                if (context.Roles.FirstOrDefault(x => x.Name.Equals(RoleTypes.User.ToString())) == null)
                {
                    context.Roles.Add(new Role
                    {
                        Deleted = false,
                        Name = RoleTypes.User.ToString()
                    });
                }

                context.SaveChanges();
            }
        }
    }
}