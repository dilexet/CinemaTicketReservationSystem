using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Movie;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Movie
{
    public class MovieResponse : Response
    {
        public MovieViewModel Movie { get; set; }
    }
}