using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Row : BasedEntity
    {
        public uint NumberRow { get; set; }

        public Guid HallId { get; set; }

        public virtual Hall Hall { get; set; }

        public virtual IEnumerable<Seat> Seats { get; set; }
    }
}