using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class Genre : BasedEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<MovieDescription> MovieDescriptions { get; set; }
    }
}