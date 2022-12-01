using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class Country : BasedEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<MovieDescription> MovieDescriptions { get; set; }
    }
}