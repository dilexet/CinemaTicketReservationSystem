﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CinemaTicketReservationSystem.BLL.Utils
{
    public class JwtService : IJwtService
    {
        private readonly IOptions<JwtOptions> _options;
        private readonly SymmetricSecurityKey _key;

        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.AccessTokenSecret));
        }

        public JwtSecurityToken Generate(TokenUserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var issuer = _options.Value.Issuer;
            var audience = _options.Value.Audience;
            var lifeTime = _options.Value.AccessTokenExpirationMinutes;

            if (string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience) || lifeTime == 0)
            {
                throw new Exception("Token options is null or empty");
            }

            DateTime now = DateTime.Now;

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var claimsIdentity = CreateClaimsIdentity(user.Id, user.UserProfileId, user.Name, user.Role);

            var payload = new JwtPayload(issuer, audience, claimsIdentity.Claims, now, now.AddMinutes(lifeTime));

            var token = new JwtSecurityToken(header, payload);

            return token;
        }

        private ClaimsIdentity CreateClaimsIdentity(Guid id, Guid userProfileId, string name, string role)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", id.ToString()),
                new Claim("UserProfileId", userProfileId.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
                new Claim("Name", name),
                new Claim("Role", role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(
                    claims,
                    "Token",
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}