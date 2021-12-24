using CinemaTicketReservationSystem.BLL.Domain.MovieModels;

namespace CinemaTicketReservationSystem.BLL.Results.Movie
{
    public class MovieServiceResult : Result
    {
        public MovieModel MovieModel { get; set; }
    }
}