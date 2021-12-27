using System;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class Movie : BasedEntity
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Session Session { get; set; }

        public virtual MovieDescription MovieDescription { get; set; }
    }
}