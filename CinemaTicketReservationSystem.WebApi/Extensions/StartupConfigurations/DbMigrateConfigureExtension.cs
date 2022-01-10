using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketReservationSystem.WebApi.Extensions.StartupConfigurations
{
    public static class DbMigrateConfigureExtension
    {
        public static void UseDbMigrateConfigure(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var services = scope.ServiceProvider;
            using var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}