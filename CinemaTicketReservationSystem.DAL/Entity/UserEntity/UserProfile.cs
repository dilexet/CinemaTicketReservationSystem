using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.UserEntity
{
    public class UserProfile : BasedEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual IEnumerable<SessionSeat> Tickets { get; set; }
    }
}