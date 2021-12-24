using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.TicketsEntity
{
    public class Ticket : BasedEntity
    {
        public decimal TotalPrice { get; set; }

        public Session Session { get; set; }

        public Seat Seat { get; set; }

        public IEnumerable<AdditionalService> AdditionalServices { get; set; }
    }
}