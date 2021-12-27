using System;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Seat : BasedEntity
    {
        public uint NumberSeat { get; set; }

        public Guid SeatTypeId { get; set; }

        public virtual SeatType SeatType { get; set; }

        public Guid SessionSeatId { get; set; }

        public virtual SessionSeat SessionSeat { get; set; }

        public Guid RowId { get; set; }

        public virtual Row Row { get; set; }
    }
}