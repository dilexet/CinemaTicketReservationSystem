using System;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class Movie : BasedEntity
    {
        public string Name { get; set; }

        public MovieDescription MovieDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}