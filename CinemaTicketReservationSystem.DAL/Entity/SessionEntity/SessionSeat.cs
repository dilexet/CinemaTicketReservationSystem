using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Enums;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionSeat : BasedEntity
    {
        public double TotalPrice { get; set; }

        public TicketState TicketState { get; set; }

        public Guid SessionId { get; set; }

        public Guid SeatId { get; set; }

        public Guid SessionSeatTypeId { get; set; }

        public virtual Session Session { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual SessionSeatType SessionSeatType { get; set; }

        public virtual IEnumerable<SessionAdditionalService> AdditionalServices { get; set; }
    }
}