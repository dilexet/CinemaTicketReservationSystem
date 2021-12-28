using System;

namespace CinemaTicketReservationSystem.BLL.Domain.MovieModels
{
    public class MovieModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PosterUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieDescriptionModel MovieDescriptionModel { get; set; }
    }
}