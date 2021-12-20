using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CinemaTicketReservationSystem.BLL.Abstract;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CinemaTicketReservationSystem.BLL.Services
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

            if (String.IsNullOrEmpty(issuer) || String.IsNullOrEmpty(audience) || lifeTime == 0)
            {
                throw new Exception("Token options is null or empty");
            }

            DateTime now = DateTime.UtcNow;

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var claimsIdentity = CreateClaimsIdentity(user.Id, user.Name, user.Role);

            var payload = new JwtPayload(issuer, audience, claimsIdentity.Claims, now,
                now.AddMinutes(lifeTime));

            var token = new JwtSecurityToken(header, payload);

            return token;
        }

        private ClaimsIdentity CreateClaimsIdentity(Guid id, string name, string role)
        {
            var claims = new List<Claim>
            {
                new("UserId", id.ToString()),
                new(ClaimsIdentity.DefaultNameClaimType, name),
                new(ClaimsIdentity.DefaultRoleClaimType, role),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}