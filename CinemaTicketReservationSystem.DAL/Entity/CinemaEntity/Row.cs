using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Row : BasedEntity
    {
        public uint NumberRow { get; set; }

        public uint NumberOfSeats { get; set; }

        public IEnumerable<Seat> Seats { get; set; }
    }
}