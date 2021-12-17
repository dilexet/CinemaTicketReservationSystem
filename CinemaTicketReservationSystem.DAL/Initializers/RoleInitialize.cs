using System.Linq;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity;
using CinemaTicketReservationSystem.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.DAL.Initializers
{
    public static class RoleInitialize
    {
        public static async Task Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role()
                    {
                        Name = RoleTypes.Admin.ToString()
                    },
                    new Role()
                    {
                        Name = RoleTypes.Manager.ToString()
                    },
                    new Role()
                    {
                        Name = RoleTypes.User.ToString()
                    }
                );

                await context.SaveChangesAsync();
            }
            else
            {
                if (await context.Roles.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.Admin.ToString())) == null)
                {
                    await context.Roles.AddAsync(new Role() {Name = RoleTypes.Admin.ToString()});
                }

                if (await context.Roles.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.Manager.ToString())) == null)
                {
                    await context.Roles.AddAsync(new Role() {Name = RoleTypes.Manager.ToString()});
                }

                if (await context.Roles.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.User.ToString())) == null)
                {
                    await context.Roles.AddAsync(new Role() {Name = RoleTypes.User.ToString()});
                }

                await context.SaveChangesAsync();
            }
        }
    }
}