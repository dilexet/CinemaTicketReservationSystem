using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Hall : BasedEntity
    {
        public string Name { get; set; }

        public uint NumberOfSeats { get; set; }

        public IEnumerable<Row> Rows { get; set; }
    }
}