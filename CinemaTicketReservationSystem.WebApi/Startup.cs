using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Services;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Initializers;
using CinemaTicketReservationSystem.DAL.Repository.Authorize;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CinemaTicketReservationSystem.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMSSqlProvider");


            // DAL
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(sqlConnectionString)
            );

            services.AddScoped<IUserRepository>(provider =>
                new UserRepository(provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<UserRepository>>()));

            services.AddScoped<IRoleRepository>(provider =>
                new RoleRepository(provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<RoleRepository>>()));

            services.AddScoped<IRefreshTokenRepository>(provider =>
                new RefreshTokenRepository(provider.GetService<ApplicationDbContext>(),
                    provider.GetService<ILogger<RefreshTokenRepository>>()));

            services.AddScoped<IAuthorizeService, AuthorizeService>();

            // Other
            // TODO: add mapper config
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            // BLL
            services.AddOptions();
            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
            services.Configure<RefreshTokenOptions>(Configuration.GetSection("RefreshTokenOptions"));

            services.AddScoped<IJwtService>(provider => new JwtService(provider.GetService<IOptions<JwtOptions>>()));

            services.AddScoped<IRefreshTokenService>(provider =>
                new RefreshTokenService(provider.GetService<IOptions<RefreshTokenOptions>>()));

            services.AddScoped<ITokenService>(provider => new TokenService(provider.GetService<IJwtService>(),
                provider.GetService<IRefreshTokenService>(), provider.GetService<IRefreshTokenRepository>()));

            services.AddScoped<IAuthorizeService>(provider =>
                new AuthorizeService(provider.GetService<IUserRepository>(),
                    provider.GetService<IRoleRepository>(), provider.GetService<ITokenService>(),
                    provider.GetService<IMapper>()));


            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = Configuration["JwtOptions:Issuer"],
                ValidAudience = Configuration["JwtOptions:Audience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtOptions:AccessTokenSecret"])),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = false;
                    options.Audience = Configuration["JwtOptions:Audience"];
                    options.TokenValidationParameters = tokenValidationParameters;
                });
            services.AddAuthorization();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1",
                    new OpenApiInfo {Title = "CinemaTicketReservationSystem.WebApi", Version = "v1"});
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter ‘Bearer’ [space] and then your valid token",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CinemaTicketReservationSystem.WebApi v1"));
            }

            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                if (scope != null)
                {
                    var services = scope.ServiceProvider;
                    using (var dbContext = services.GetRequiredService<ApplicationDbContext>())
                    {
                        await dbContext.Database.MigrateAsync();
                        await RoleInitialize.Seed(dbContext);
                    }
                }
            }

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}