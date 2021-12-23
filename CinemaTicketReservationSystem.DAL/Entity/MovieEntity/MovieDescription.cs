using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class MovieDescription : BasedEntity
    {
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Directors { get; set; }

        public IEnumerable<string> Screenwriters { get; set; }

        public IEnumerable<string> Producers { get; set; }

        public IEnumerable<string> Actors { get; set; }
    }
}