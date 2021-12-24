using System;
using CinemaTicketReservationSystem.DAL.Entity.TicketsEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Seat : BasedEntity
    {
        public uint NumberSeat { get; set; }

        public Guid SeatTypeId { get; set; }

        public SeatType SeatType { get; set; }

        public Guid TicketId { get; set; }

        public Ticket Ticket { get; set; }

        public Guid RowId { get; set; }

        public Row Row { get; set; }
    }
}