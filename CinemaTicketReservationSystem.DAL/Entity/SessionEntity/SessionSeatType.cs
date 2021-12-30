using System;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionSeatType : BasedEntity
    {
        public double Price { get; set; }

        public string SeatType { get; set; }

        public Guid SessionSeatId { get; set; }

        public virtual SessionSeat SessionSeat { get; set; }
    }
}