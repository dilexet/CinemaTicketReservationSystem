using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.BookingEntity
{
    public class BookedOrder : BasedEntity
    {
        public double TotalPrice { get; set; }

        public Guid UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual IEnumerable<SessionSeat> ReservedSessionSeats { get; set; }

        public virtual IEnumerable<BookedService> SelectedAdditionalServices { get; set; }
    }
}