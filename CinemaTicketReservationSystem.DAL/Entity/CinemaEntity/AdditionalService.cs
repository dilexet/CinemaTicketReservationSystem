using System;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class AdditionalService : BasedEntity
    {
        public string Name { get; set; }

        public Guid CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual SessionAdditionalService SessionAdditionalService { get; set; }
    }
}