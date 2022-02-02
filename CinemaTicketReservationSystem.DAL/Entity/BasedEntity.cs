using System;

namespace CinemaTicketReservationSystem.DAL.Entity
{
    public class BasedEntity
    {
        public Guid Id { get; set; }

        public bool Deleted { get; set; }
    }
}