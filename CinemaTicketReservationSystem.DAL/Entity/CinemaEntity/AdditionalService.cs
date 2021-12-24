using System;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Entity.TicketsEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class AdditionalService : BasedEntity
    {
        public string Name { get; set; }

        public Guid TicketId { get; set; }

        public Ticket Ticket { get; set; }

        public Guid SessionAdditionalServiceId { get; set; }

        public SessionAdditionalService SessionAdditionalService { get; set; }
    }
}