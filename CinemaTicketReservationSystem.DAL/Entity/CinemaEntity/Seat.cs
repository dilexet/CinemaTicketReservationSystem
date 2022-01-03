using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Seat : BasedEntity
    {
        public uint NumberSeat { get; set; }

        public string SeatType { get; set; }

        public virtual IEnumerable<SessionSeat> SessionSeats { get; set; }

        public Guid RowId { get; set; }

        public virtual Row Row { get; set; }
    }
}