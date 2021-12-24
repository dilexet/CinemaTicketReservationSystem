using System;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionSeatType : BasedEntity
    {
        public decimal Price { get; set; }

        public Guid SeatTypeId { get; set; }

        public SeatType SeatType { get; set; }

        public Guid SessionId { get; set; }

        public Session Session { get; set; }
    }
}