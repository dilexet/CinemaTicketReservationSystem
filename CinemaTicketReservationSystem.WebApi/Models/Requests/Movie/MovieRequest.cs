using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Movie
{
    public class MovieRequest
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}