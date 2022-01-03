using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class AdditionalService : BasedEntity
    {
        public string Name { get; set; }

        public Guid CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual IEnumerable<SessionAdditionalService> SessionAdditionalServices { get; set; }
    }
}