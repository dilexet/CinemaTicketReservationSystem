using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Domain.MovieModels
{
    public class MovieDescriptionModel
    {
        public Guid Id { get; set; }

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