using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Movie
{
    public class MovieServiceResult : Result
    {
        public MovieModel MovieModel { get; set; }
    }
}