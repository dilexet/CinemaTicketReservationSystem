using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.TicketsEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class Session : BasedEntity
    {
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }

        public Guid HallId { get; set; }

        public Hall Hall { get; set; }

        public Guid CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public DateTime StartDate { get; set; }

        public IEnumerable<SessionSeatType> SessionSeatTypes { get; set; }

        public IEnumerable<SessionAdditionalService> SessionAdditionalServices { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}