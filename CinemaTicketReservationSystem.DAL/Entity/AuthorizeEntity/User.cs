﻿using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity
{
    public class User : BasedEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual Role Role { get; set; }

        public virtual IEnumerable<RefreshToken> RefreshTokens { get; set; }
    }
}