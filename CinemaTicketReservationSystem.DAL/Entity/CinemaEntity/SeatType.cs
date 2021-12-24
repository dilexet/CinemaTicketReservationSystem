using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class SeatType : BasedEntity
    {
        public string Name { get; set; }

        public IEnumerable<Seat> Seat { get; set; }

        public Guid SessionSeatTypeId { get; set; }

        public SessionSeatType SessionSeatType { get; set; }
    }
}