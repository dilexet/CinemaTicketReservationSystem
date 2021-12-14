using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CinemaTicketReservationSystem.WebApi.Jwt
{
    public class JwtService
    {
        private readonly IOptions<JwtOptions> _options;
        private readonly SymmetricSecurityKey _key;

        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));
        }

        public string Generate(ClaimsIdentity identity)
        {
            var issuer = _options.Value.Issuer;
            var audience = _options.Value.Audience;
            var lifeTime = _options.Value.LifeTime;

            DateTime now = DateTime.UtcNow;

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(issuer, audience, identity.Claims, now,
                now.Add(TimeSpan.FromMinutes(lifeTime)));

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}