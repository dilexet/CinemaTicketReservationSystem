using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Initializers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketReservationSystem.WebApi.Extensions
{
    public static class DbMigrateConfigureExtension
    {
        public static void UseDbMigrateConfigure(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                if (scope != null)
                {
                    var services = scope.ServiceProvider;
                    using (var context = services.GetRequiredService<ApplicationDbContext>())
                    {
                        context.Database.Migrate();
                        RoleInitialize.Seed(context);
                    }
                }
            }
        }
    }
}