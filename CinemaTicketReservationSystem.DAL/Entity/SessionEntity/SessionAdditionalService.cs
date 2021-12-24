using System;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionAdditionalService : BasedEntity
    {
        public decimal Price { get; set; }

        public Guid AdditionalServiceId { get; set; }

        public AdditionalService AdditionalService { get; set; }

        public Guid SessionId { get; set; }

        public Session Session { get; set; }
    }
}