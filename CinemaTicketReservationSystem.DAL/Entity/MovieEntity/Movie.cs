using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class Movie : BasedEntity
    {
        public string Name { get; set; }

        public Uri PosterUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual IEnumerable<Session> Sessions { get; set; }

        public virtual MovieDescription MovieDescription { get; set; }
    }
}