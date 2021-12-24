using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class Session : BasedEntity
    {
        public Movie Movie { get; set; }

        public Hall Hall { get; set; }

        public Cinema Cinema { get; set; }

        public DateTime StartDate { get; set; }

        public IEnumerable<SessionSeatType> SessionSeatTypes { get; set; }

        public IEnumerable<SessionAdditionalService> SessionAdditionalServices { get; set; }
    }
}