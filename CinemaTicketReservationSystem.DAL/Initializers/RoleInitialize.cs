using System.Linq;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Enums;

namespace CinemaTicketReservationSystem.DAL.Initializers
{
    public static class RoleInitialize
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role()
                    {
                        Name = RoleTypes.Admin.ToString(),
                    },
                    new Role()
                    {
                        Name = RoleTypes.Manager.ToString(),
                    },
                    new Role()
                    {
                        Name = RoleTypes.User.ToString(),
                    });

                context.SaveChanges();
            }
            else
            {
                if (context.Roles.SingleOrDefault(x => x.Name.Equals(RoleTypes.Admin.ToString())) == null)
                {
                    context.Roles.Add(new Role() { Name = RoleTypes.Admin.ToString() });
                }

                if (context.Roles.SingleOrDefault(x => x.Name.Equals(RoleTypes.Manager.ToString())) == null)
                {
                    context.Roles.Add(new Role() { Name = RoleTypes.Manager.ToString() });
                }

                if (context.Roles.SingleOrDefault(x => x.Name.Equals(RoleTypes.User.ToString())) == null)
                {
                    context.Roles.Add(new Role() { Name = RoleTypes.User.ToString() });
                }

                context.SaveChanges();
            }
        }
    }
}