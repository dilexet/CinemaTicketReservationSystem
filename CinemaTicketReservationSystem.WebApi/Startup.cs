using System;
using System.Reflection;
using System.Text;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Services;
using CinemaTicketReservationSystem.BLL.Utils;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Enums;
using CinemaTicketReservationSystem.DAL.Initializers;
using CinemaTicketReservationSystem.DAL.Repository.Authorize;
using CinemaTicketReservationSystem.WebApi.CustomFilters;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Token;
using CinemaTicketReservationSystem.WebApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = Configuration["JwtOptions:Issuer"],
                ValidAudience = Configuration["JwtOptions:Audience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtOptions:AccessTokenSecret"])),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true
            };

            services.AddAuthentication(
                    option =>
                    {
                        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.Audience = Configuration["JwtOptions:Audience"];
                    options.TokenValidationParameters = tokenValidationParameters;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRole", policy =>
                    policy.RequireRole(RoleTypes.Admin.ToString()));
            });

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "CinemaTicketReservationSystem.WebApi", Version = "v1"
                    });
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
                    using (var context = services.GetRequiredService<ApplicationDbContext>())
                    {
                        context.Database.Migrate();
                        RoleInitialize.Seed(context);
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