using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieFilter;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.MovieFilter
{
    public class GetSessionsResult : Result
    {
        public IEnumerable<SessionsForMovieModel> Sessions { get; set; }

        public MovieModel Movie { get; set; }
    }
}