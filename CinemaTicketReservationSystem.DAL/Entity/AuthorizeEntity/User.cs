using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity
{
    public class User : BasedEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }

        public IEnumerable<RefreshToken> RefreshTokens { get; set; }
    }
}