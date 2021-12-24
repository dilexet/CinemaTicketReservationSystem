using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Enums;

namespace CinemaTicketReservationSystem.DAL.Entity.TicketEntity
{
    public class Ticket : BasedEntity
    {
        public double TotalPrice { get; set; }

        public TicketState TicketState { get; set; }

        public Guid SessionId { get; set; }

        public Guid SeatId { get; set; }

        public Session Session { get; set; }

        public Seat Seat { get; set; }

        public IEnumerable<AdditionalService> AdditionalServices { get; set; }
    }
}