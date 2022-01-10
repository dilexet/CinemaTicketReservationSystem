using System;
using System.Reflection;
using CinemaTicketReservationSystem.DAL.Initializers;
using CinemaTicketReservationSystem.WebApi.CustomFilters;
using CinemaTicketReservationSystem.WebApi.Extensions.StartupConfigurations;
using CinemaTicketReservationSystem.WebApi.Hubs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CinemaTicketReservationSystem.WebApi
{
    public class Startup
    {
        private const string NameCorsPolicy = "DefaultCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsToConfigureServices(Configuration, NameCorsPolicy);

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.DateFormatString = Configuration["DateTime:Format"]);

            services.AddMvc(config =>
                {
                    config.Filters.Add(typeof(CustomExceptionFilter));
                    config.Filters.Add(typeof(CustomValidationFilterAttribute));
                })
                .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSignalR();

            services.AddMemoryCache();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDataAccessServicesToConfigureServices(Configuration);

            services.AddOptions();

            services.AddBusinessLogicServicesToConfigureServices(Configuration);

            services.AddAuthenticationToConfigureServices(Configuration);

            services.AddSwaggerToConfigureServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(NameCorsPolicy);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfigure();
            }

            app.UseSerilogRequestLogging();
            app.UseDbMigrateConfigure();

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SeatBookingHub>("/seat-booking-hub");
            });

            RoleInitialize.Seed(app.ApplicationServices);
        }
    }
}