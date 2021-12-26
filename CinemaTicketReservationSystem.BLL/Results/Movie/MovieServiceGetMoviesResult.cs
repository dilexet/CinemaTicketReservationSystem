using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;

namespace CinemaTicketReservationSystem.BLL.Results.Movie
{
    public class MovieServiceGetMoviesResult : Result
    {
        public IEnumerable<MovieModel> MovieModels { get; set; }
    }
}