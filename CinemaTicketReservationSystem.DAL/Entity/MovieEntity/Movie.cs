using System;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class Movie : BasedEntity
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid MovieDescriptionId { get; set; }

        public Session Session { get; set; }

        public MovieDescription MovieDescription { get; set; }
    }
}