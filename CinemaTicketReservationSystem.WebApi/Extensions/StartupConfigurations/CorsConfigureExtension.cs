using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketReservationSystem.WebApi.Extensions.StartupConfigurations
{
    public static class CorsConfigureExtension
    {
        public static void AddCorsToConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration,
            string nameCorsPolicy)
        {
            var originHttp = configuration["Origins:HttpOrigin"];
            var originHttps = configuration["Origins:HttpsOrigin"];

            services.AddCors(options =>
            {
                options.AddPolicy(nameCorsPolicy, builder =>
                {
                    builder
                        .WithOrigins(originHttp, originHttps)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(_ => true)
                        .AllowCredentials();
                });
            });
        }
    }
}