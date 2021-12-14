using System.Collections.Generic;
using System.Security.Claims;

namespace CinemaTicketReservationSystem.WebApi.Jwt
{
    public class IdentityService
    {
        public ClaimsIdentity CreateClaimsIdentity(string name, string role)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, name),
                new(ClaimsIdentity.DefaultRoleClaimType, role)
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}