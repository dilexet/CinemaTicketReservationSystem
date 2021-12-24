using System;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class MovieDescription : BasedEntity
    {
        public Guid MovieId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public string[] Countries { get; set; }

        public string[] Genres { get; set; }

        public string[] Directors { get; set; }

        public string[] Screenwriters { get; set; }

        public string[] Producers { get; set; }

        public string[] Actors { get; set; }

        public Movie Movie { get; set; }
    }
}