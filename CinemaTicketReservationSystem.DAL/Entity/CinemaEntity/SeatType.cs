using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class SeatType : BasedEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Seat> Seat { get; set; }

        public virtual SessionSeatType SessionSeatType { get; set; }
    }
}