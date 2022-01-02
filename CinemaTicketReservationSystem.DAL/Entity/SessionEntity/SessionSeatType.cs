using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionSeatType : BasedEntity
    {
        public double Price { get; set; }

        public string SeatType { get; set; }

        public virtual Guid SessionId { get; set; }

        public virtual Session Session { get; set; }

        public virtual IEnumerable<SessionSeat> SessionSeats { get; set; }
    }
}