using System;
using System.Text;
using CinemaTicketReservationSystem.DAL.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CinemaTicketReservationSystem.WebApi.Extensions
{
    public static class AuthenticationConfigureExtension
    {
        public static void AddAuthenticationToConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = configuration["JwtOptions:Issuer"],
                ValidAudience = configuration["JwtOptions:Audience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtOptions:AccessTokenSecret"])),
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
                    options.Audience = configuration["JwtOptions:Audience"];
                    options.TokenValidationParameters = tokenValidationParameters;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRole", policy =>
                    policy.RequireRole(RoleTypes.Admin.ToString()));
                options.AddPolicy("UserRole", policy =>
                    policy.RequireRole(RoleTypes.User.ToString()));
                options.AddPolicy("ManagerRole", policy =>
                    policy.RequireRole(RoleTypes.Manager.ToString()));
            });
        }
    }
}