using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.TicketsEntity
{
    public class Ticket : BasedEntity
    {
        public Seat Seat { get; set; }

        public IEnumerable<AdditionalServices> AdditionalServices { get; set; }
    }
}