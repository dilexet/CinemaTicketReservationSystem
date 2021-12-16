using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public Role Role { get; set; }
        public IEnumerable<RefreshToken> RefreshTokens { get; set; }
    }
}