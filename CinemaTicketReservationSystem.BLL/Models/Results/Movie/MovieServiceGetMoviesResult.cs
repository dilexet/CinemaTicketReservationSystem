using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Movie
{
    public class MovieServiceGetMoviesResult : Result
    {
        public IEnumerable<MovieModel> MovieModels { get; set; }
    }
}