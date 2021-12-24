using System;
using System.Reflection;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Services;
using CinemaTicketReservationSystem.BLL.Utils;
using CinemaTicketReservationSystem.DAL.Abstract.Authorize;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Repository.Authorize;
using CinemaTicketReservationSystem.WebApi.CustomFilters;
using CinemaTicketReservationSystem.WebApi.Extensions;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Token;
using CinemaTicketReservationSystem.WebApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(config =>
                {
                    config.Filters.Add(typeof(CustomExceptionFilter));
                    config.Filters.Add(typeof(CustomValidationFilterAttribute));
                })
                .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMSSqlProvider");

            // DAL
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(sqlConnectionString));

            services.AddScoped<IUserRepository>(provider =>
                new UserRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<UserRepository>>()));

            services.AddScoped<IRoleRepository>(provider =>
                new RoleRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<RoleRepository>>()));

            services.AddScoped<IRefreshTokenRepository>(provider =>
                new RefreshTokenRepository(
                    provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<RefreshTokenRepository>>()));

            services.AddScoped<IAuthorizeService, AuthorizeService>();

            // Other
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Validators
            services.AddTransient<IValidator<UserLoginRequest>, UserLoginRequestValidator>();
            services.AddTransient<IValidator<UserRegisterRequest>, UserRegisterRequestValidator>();
            services.AddTransient<IValidator<RefreshTokenRequest>, RefreshTokenRequestValidator>();

            // BLL
            services.AddOptions();
            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
            services.Configure<RefreshTokenOptions>(Configuration.GetSection("RefreshTokenOptions"));

            services.AddScoped<IJwtService>(provider => new JwtService(provider.GetService<IOptions<JwtOptions>>()));

            services.AddScoped<IRefreshTokenService>(provider =>
                new RefreshTokenService(provider.GetService<IOptions<RefreshTokenOptions>>()));

            services.AddScoped<ITokenService>(provider => new TokenService(
                provider.GetService<IJwtService>(),
                provider.GetService<IRefreshTokenService>(),
                provider.GetService<IRefreshTokenRepository>()));

            services.AddScoped<IAuthorizeService>(provider =>
                new AuthorizeService(
                    provider.GetService<IUserRepository>(),
                    provider.GetService<IRoleRepository>(),
                    provider.GetService<ITokenService>(),
                    provider.GetService<IMapper>()));

            services.AddScoped<IUserManagement>(provider =>
                new UserManagement(
                    provider.GetService<IUserRepository>(),
                    provider.GetService<IRoleRepository>(),
                    provider.GetService<IMapper>()));

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

            app.UseDbMigrateConfigure();

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}