using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.UserEntity
{
    public class UserProfile : BasedEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual IEnumerable<BookedOrder> Tickets { get; set; }
    }
}