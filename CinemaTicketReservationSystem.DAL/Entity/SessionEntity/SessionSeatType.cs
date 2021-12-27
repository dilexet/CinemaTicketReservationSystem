using System;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionSeatType : BasedEntity
    {
        public double Price { get; set; }

        public Guid SeatTypeId { get; set; }

        public virtual SeatType SeatType { get; set; }

        public virtual SessionSeat SessionSeat { get; set; }
    }
}