using System;
using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Enums;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionSeat : BasedEntity
    {
        public TicketState TicketState { get; set; }

        public Guid SessionId { get; set; }

        public Guid SeatId { get; set; }

        public Guid SessionSeatTypeId { get; set; }

        public Guid? BookedOrderId { get; set; }

        public virtual BookedOrder BookedOrder { get; set; }

        public virtual Session Session { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual SessionSeatType SessionSeatType { get; set; }
    }
}