using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class MovieDescription : BasedEntity
    {
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual IEnumerable<Genre> Genres { get; set; }

        public virtual IEnumerable<Country> Countries { get; set; }
    }
}