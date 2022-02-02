using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class Session : BasedEntity
    {
        public DateTime StartDate { get; set; }

        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public Guid HallId { get; set; }

        public virtual Hall Hall { get; set; }

        public virtual IEnumerable<SessionAdditionalService> SessionAdditionalServices { get; set; }

        public virtual IEnumerable<SessionSeatType> SessionSeatType { get; set; }

        public virtual IEnumerable<SessionSeat> SessionSeats { get; set; }
    }
}