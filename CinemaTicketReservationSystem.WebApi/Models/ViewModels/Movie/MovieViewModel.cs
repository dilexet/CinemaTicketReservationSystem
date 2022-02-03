using System;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Movie
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PosterUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieDescriptionViewModel MovieDescription { get; set; }
    }
}